using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class EnemyAI : MonoBehaviour
{
    [Header("Patrulha Aleatória")]
    public float patrolRadius = 8f;           // raio em torno da posição inicial para escolher pontos aleatórios
    public float patrolSpeed = 2f;            // velocidade ao patrulhar
    public float timeBetweenPoints = 0.5f;    // tempo mínimo antes de escolher novo ponto (para evitar trocas instantâneas)

    [Header("Perseguição")]
    public float chaseSpeed = 4.5f;
    public float detectionRange = 12f;
    [Range(0f, 180f)]
    public float detectionAngle = 60f;

    [Header("Passos")]
    public AudioClip footstepClip;
    public float baseStepInterval = 0.45f;    // base; será ajustado conforme velocidade
    public float minSpeedForSteps = 0.1f;

    [Header("Referências")]
    public Transform player;                  // arraste o transform do jogador aqui
    public Transform eyes;                    // opcional, posição dos "olhos" (se vazio usa transform + 1.2f up)

    [Header("Debug")]
    public bool drawDebug = false;

    CharacterController controller;
    AudioSource audioSource;
    Vector3 startPos;
    Vector3 currentPatrolTarget;
    bool hasTarget = false;
    float chooseTimer = 0f;

    enum State { Patrol, Chasing }
    State state = State.Patrol;

    float stepTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;

        startPos = transform.position;
        PickNewPatrolPointImmediate();

        if (player == null)
            Debug.LogWarning("EnemyAI_RandomPatrol: arraste o Transform do player no campo 'player' no Inspector.");
        if (controller == null)
            Debug.LogWarning("EnemyAI_RandomPatrol: CharacterController não encontrado no GameObject.");
        if (footstepClip == null)
            Debug.LogWarning("EnemyAI_RandomPatrol: adicione um AudioClip em 'footstepClip' para os passos.");
    }

    void Update()
    {
        // estado por detecção do jogador
        if (player != null && CheckSeePlayer())
            state = State.Chasing;
        else
            state = State.Patrol;

        if (state == State.Patrol)
            PatrolUpdate();
        else
            ChaseUpdate();

        HandleFootsteps();
    }

    void PatrolUpdate()
    {
        chooseTimer += Time.deltaTime;

        // se não tem alvo (ou alcançou), escolher um novo ponto
        if (!hasTarget || Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                           new Vector3(currentPatrolTarget.x, 0, currentPatrolTarget.z)) < 0.4f)
        {
            if (chooseTimer >= timeBetweenPoints)
            {
                PickNewPatrolPoint();
                chooseTimer = 0f;
            }
            else
            {
                // ficar parado até o timer permitir novo ponto (simples)
                controller.SimpleMove(Vector3.zero);
                return;
            }
        }

        MoveTowards(currentPatrolTarget, patrolSpeed);
    }

    void ChaseUpdate()
    {
        Vector3 target = player.position;
        MoveTowards(target, chaseSpeed);
    }

    void MoveTowards(Vector3 worldTarget, float speed)
    {
        Vector3 dir = worldTarget - transform.position;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.001f)
        {
            controller.SimpleMove(Vector3.zero);
            return;
        }

        Vector3 moveDir = dir.normalized;

        // rotaciona suavemente para frente
        Quaternion look = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 6f);

        controller.SimpleMove(moveDir * speed);
    }

    void PickNewPatrolPointImmediate()
    {
        currentPatrolTarget = RandomPointInRadius();
        hasTarget = true;
        chooseTimer = 0f;
    }

    void PickNewPatrolPoint()
    {
        currentPatrolTarget = RandomPointInRadius();
        hasTarget = true;
    }

    Vector3 RandomPointInRadius()
    {
        Vector2 rand = Random.insideUnitCircle * patrolRadius;
        Vector3 cand = startPos + transform.right * rand.x + transform.forward * rand.y;

        // mantém a mesma altura Y do startPos para simplicidade
        cand.y = startPos.y;
        return cand;
    }

    bool CheckSeePlayer()
    {
        Vector3 eyePos = (eyes != null) ? eyes.position : transform.position + Vector3.up * 1.2f;
        Vector3 toPlayer = player.position - eyePos;
        float dist = toPlayer.magnitude;
        if (dist > detectionRange) return false;

        float angle = Vector3.Angle(transform.forward, toPlayer);
        if (angle > detectionAngle) return false;

        Ray ray = new Ray(eyePos, toPlayer.normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            if (hit.transform == player || hit.transform.IsChildOf(player))
                return true;
            else
                return false; // obstruído
        }
        return false;
    }

    void HandleFootsteps()
    {
        if (footstepClip == null || audioSource == null || controller == null) return;

        Vector3 horizVel = new Vector3(controller.velocity.x, 0f, controller.velocity.z);
        float speed = horizVel.magnitude;
        bool isMoving = speed > minSpeedForSteps && controller.isGrounded;

        if (isMoving)
        {
            // ajusta intervalo de passos com base na velocidade
            float effectiveSpeed = Mathf.Max(0.01f, speed);
            float interval = baseStepInterval * ((state == State.Chasing ? chaseSpeed : patrolSpeed) / effectiveSpeed);

            stepTimer += Time.deltaTime;
            if (stepTimer >= interval)
            {
                audioSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (!drawDebug) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPos, patrolRadius);

        // cone simples
        Vector3 eyePos = (eyes != null) ? eyes.position : transform.position + Vector3.up * 1.2f;
        Quaternion leftRot = Quaternion.Euler(0, -detectionAngle, 0);
        Quaternion rightRot = Quaternion.Euler(0, detectionAngle, 0);
        Vector3 leftDir = leftRot * transform.forward;
        Vector3 rightDir = rightRot * transform.forward;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(eyePos, eyePos + leftDir * detectionRange);
        Gizmos.DrawLine(eyePos, eyePos + rightDir * detectionRange);

        // alvo atual de patrulha
        if (hasTarget)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(currentPatrolTarget, 0.15f);
        }
    }
}