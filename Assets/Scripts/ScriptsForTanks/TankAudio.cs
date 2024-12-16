using UnityEngine;

public class TankAudio : MonoBehaviour
{
    [Header("Audio Engine")]
    public AudioSource tanksAudio;
    public float tanksSoundPitch = 0.7f;

    public void DinamicMove(float ver)                                       // Метод для динамичного движения со звуком
                                                                             // (чтобы он не просто передвигался с одинаковым звуком как при движении так и при тормозе,
                                                                             // а чтоб плавно переходил с помощью изменения звука)
    {
        if (ver > 0)
        {
            tanksAudio.pitch = Mathf.Clamp(tanksSoundPitch += 0.1f * Time.deltaTime, 0.7f, 1.1f);

            if (tanksSoundPitch < 0.7f) tanksSoundPitch = 0.7f;
        }

        else
        {
            tanksAudio.pitch = Mathf.Clamp(tanksSoundPitch -= 0.1f * Time.deltaTime, 0.7f, 1.1f);

            if (tanksSoundPitch > 1.1f) tanksSoundPitch = 1.1f;
        }

    }
}
