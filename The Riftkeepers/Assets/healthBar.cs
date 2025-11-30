using UnityEngine;
using UnityEngine.UIElements;

public class healthBar : MonoBehaviour
{

    public CharStats CharStats;
    public UIDocument UIDoc;

    private VisualElement bar;
    private int currentHp;
    private int Hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = CharStats.currentHealth;
        Hp = CharStats.health.value;

        bar = UIDoc.rootVisualElement.Q<VisualElement>("BarMask");
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = CharStats.currentHealth;
        
        float healthRatio = (float)currentHp / Hp;
        float healthPercent = Mathf.Lerp(8, 88, healthRatio);
        bar.style.width = Length.Percent(healthPercent);
    }
}
