using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthPanel : MonoBehaviour
{
    public Text healthText;
    public Button damageButton;
    public Button healButton;

    private IDamageable damageable;
    private IHealable healable;

    void Start()
    {
        damageable = GetComponent<IDamageable>();
        healable = GetComponent<IHealable>();

        damageButton.onClick.AddListener(ApplyDamage);
        healButton.onClick.AddListener(ApplyHeal);

        UpdateHealthText();
    }

    void ApplyDamage()
    {
        if (damageable != null)
        {
            damageable.Damage(10); // Apply damage
            UpdateHealthText();
        }
    }

    void ApplyHeal()
    {
        if (healable != null)
        {
            healable.Heal(10); // Apply healing
            UpdateHealthText();
        }
    }

    void UpdateHealthText()
    {
        if (damageable != null)
        {
            healthText.text = "Health: " + damageable.Health;
        }
    }
}