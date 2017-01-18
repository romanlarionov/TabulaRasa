
using UnityEngine;
using System.Collections;

public class ParticleAttractor : MonoBehaviour {
	
	public ParticleSystem[] systems;
	private float radius  = 10f;
	public float power    = 1f;
	public float maxPower = 100f;
	public float speed    = 5f;

	void Update() {
		int len = systems.Length;
		for(int j = 0; j < len; j++) {
			
			ParticleSystem system = systems[j];
			ParticleSystem.Particle[] particles = new ParticleSystem.Particle[system.particleCount];
			
			system.GetParticles(particles);
			
			for(int i=0; i<system.particleCount; i++){

				Vector3 pos = particles[i].position;//t.TransformPoint();
				Debug.DrawLine(pos, transform.position, new Color(1,0.5f, 0.5f, 0.25f));
				Vector3 dir = transform.position - pos;
				float amount = (1 - dir.magnitude / radius) * power / maxPower;
				dir.Normalize();
				particles[i].velocity = Vector3.Lerp(particles[i].velocity, dir * speed, amount * Time.deltaTime);
			}
			system.SetParticles(particles, particles.Length);
		}
	}
}