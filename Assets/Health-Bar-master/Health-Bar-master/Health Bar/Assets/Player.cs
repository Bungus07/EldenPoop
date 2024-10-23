using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	private Rigidbody rb;

	public HealthBar2 healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		rb = GetComponent<Rigidbody>();
    }
	void GameOver()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    private void OnCollisionEnter(Collision collision)
    {
		Debug.Log("PlayerHasCollidedWith " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
		{
			TakeDamage(collision.gameObject.GetComponent<EnemyControls>().EnemyDamage);
			rb.AddForce(-transform.forward * collision.gameObject.GetComponent<EnemyControls>().KnockBackDistance);
			Debug.Log("PlayerHasTakenDamage");
		}
        if (collision.gameObject.tag == "Boss")
        {
            TakeDamage(collision.gameObject.transform.parent.GetComponent<EnemyControls>().EnemyDamage);
            rb.AddForce(-transform.forward * collision.gameObject.transform.parent.GetComponent<EnemyControls>().KnockBackDistance);
            Debug.Log("PlayerHasTakenDamage");
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F))
		{
			TakeDamage(3);
		}
		if (currentHealth <= 0)
		{
			GameOver();
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
