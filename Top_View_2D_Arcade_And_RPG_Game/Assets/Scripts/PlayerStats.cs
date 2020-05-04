using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public new string name = "Bear";
    public int damage;
    public int maxHealth = 5;
    public int currentHealth;
    public Animator animator;
    public BoxCollider2D dmg;
    public PlayerController pc;
    public Material activeMaterial;
    public Material disactiveMaterial;
    public Material firstMaterial;
    public TextMeshProUGUI ohNo;
    public TextMeshProUGUI youShould;
    public TextMeshProUGUI space;
    public TextMeshProUGUI displayTime;
    public RectTransform panel;
    public RectTransform panel2;
    public Image blur;
    public Image violetBG;
    public Image resume;
    public Image restart;
    public Image menu;
    public static bool gameIsPaused;
    public HealthHeart[] z;

    public string getName()
    {
        return name;
    }

    public void setName(string nm)
    {
        name = nm;
    }

    void Awake()
    {
        currentHealth = 3;
        for (int i = 0; i < currentHealth; i++)
        {
            firstMaterial = activeMaterial;
        }
        ohNo.text = "Oh no! The bear has been hunted!";
        youShould.text = "You should be more careful next time!";
        space.text = "(Press 'space' key to reload the level...)";
        ohNo.gameObject.SetActive(false);
        youShould.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        space.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (currentHealth > 0) && (displayTime.gameObject.activeInHierarchy==false))
        {
            if (Time.timeScale == 1)
            {
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                hidePaused();
            }
        }
        if ((Time.timeScale == 0)&&(gameIsPaused==false))
        {
            if (Input.GetKeyDown("space"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacles")
        {
            TakeDamage(1);
            StartCoroutine(Animacja());
        }
        if (collision.collider.tag == "Boost")
        {
            Boost(1);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Villagers")
        {
            TakeDamage(maxHealth);
        }
    }

    IEnumerator Animacja()
    {
        dmg.enabled = false;
        animator.SetBool("IsCollision", true);
        pc.moveSpeed -= 10f;
        yield return new WaitForSeconds(2);
        dmg.enabled = true;
        animator.SetBool("IsCollision", false);
        pc.moveSpeed += 10f;
    }

    public void TakeDamage(int damage)
    {
        name = "Bear";
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            z[currentHealth].set(disactiveMaterial);
            Debug.Log(name + " takes " + damage + " point of damage.\nYou have " + currentHealth + " points of health.");
        }
        if (currentHealth <= 0)
        {
            Die();
            z[0].set(disactiveMaterial);
            z[1].set(disactiveMaterial);
            z[2].set(disactiveMaterial);
            z[3].set(disactiveMaterial);
            z[4].set(disactiveMaterial);
        }
    }

    public void Boost(int boost)
    {
        currentHealth += boost;
        z[currentHealth - 1].set(activeMaterial);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("You have maximum health points!");
        }
        if (currentHealth < maxHealth)
        {
            Debug.Log("Hooray! You got " + boost + " health point!\nYou have " + currentHealth + " points of health.");
        }
    }

    public virtual void Die()
    {
        Debug.Log("Oh, " + name + " has been hunted.\nYou should be more careful next time!");
        blur.gameObject.SetActive(true);
        violetBG.gameObject.SetActive(true);
        ohNo.gameObject.SetActive(true);
        youShould.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        space.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void showPaused()
    {
        Time.timeScale = 0;
        resume.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        panel2.gameObject.SetActive(true);
        blur.gameObject.SetActive(true);
        violetBG.gameObject.SetActive(true);
        gameIsPaused = true;
    }

    public void hidePaused()
    {
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        blur.gameObject.SetActive(false);
        violetBG.gameObject.SetActive(false);
        gameIsPaused = false;
    }

    public void Resume()
    {
        hidePaused();
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
