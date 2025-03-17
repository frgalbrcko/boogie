using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ENEMY : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent ai;
    public Transform player;
    public Camera playerCam;

    public float aiSpeed;
    public float catchDistance;

    public Image[] jumpscareImages; // Pole obrázků (tři obrázky)
    public AudioSource jumpscareSound;
    public float jumpscareDuration = 1f; // Jak dlouho jumpscare trvá
    public float imageSwitchSpeed = 0.1f; // Rychlost blikání obrázků

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);
        float distance = Vector3.Distance(transform.position, player.position);

        if (GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            ai.speed = 0;
            ai.SetDestination(transform.position);
        }
        else
        {
            ai.speed = aiSpeed;
            ai.destination = player.position;

            if (distance <= catchDistance)
            {
                player.gameObject.SetActive(false); // Deaktivujeme hráče
                StartCoroutine(TriggerJumpscare()); // Spustíme jumpscare efekt
            }
        }
    }

    IEnumerator TriggerJumpscare()
    {
        if (jumpscareSound != null)
        {
            jumpscareSound.Play(); // Přehrajeme zvuk jumpscare
        }

        float timer = 0f;
        int currentImage = 0;

        while (timer < jumpscareDuration)
        {
            // Deaktivujeme všechny obrázky
            foreach (Image img in jumpscareImages)
            {
                img.gameObject.SetActive(false);
            }

            // Aktivujeme pouze jeden obrázek (blikání)
            jumpscareImages[currentImage].gameObject.SetActive(true);

            // Přepneme na další obrázek
            currentImage = (currentImage + 1) % jumpscareImages.Length;

            yield return new WaitForSeconds(imageSwitchSpeed); // Rychlost blikání
            timer += imageSwitchSpeed;
        }

        // Po skončení jumpscare vypneme všechny obrázky
        foreach (Image img in jumpscareImages)
        {
            img.gameObject.SetActive(false);
        }

        Application.Quit(); // Vypneme hru

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Vypne hru v editoru
#endif
    }
}