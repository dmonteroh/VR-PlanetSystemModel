using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumScript : MonoBehaviour
{
    [SerializeField] public float baseSpeed = 1f;
    public GameObject Sun;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;

    public Vector3 sunPosition;

    private bool orbitActive = true;

    // Sphere rotations
    // sun rotates every ~629.76hrs. 360/629.76 ~~ 0,571
    private readonly float sunRotation = 360f / 629.76f;
    // Mercury rotates every ~1407,5hrs and orbits the sun every ~2112hrs
    private readonly float mercuryRotation = 360f / 1407.5f;
    private readonly double mercuryOrbit = 360f / 2112f;
    private double mercuryProgress = 10f;
    // Venus rotates every ~5832hrs and orbits the sun every ~ 13482hrs (retrograde/contrary to earth)
    private readonly float venusRotation = 360f / 13482f;
    private readonly double venusOrbit = 360f / 13482f;
    private double venusProgress = 20f;
    // Earth rotates every ~24hrs. 360/24 and orbits the sun every ~ 8766.144hrs
    private readonly float earthRotation = 360f / 24f;
    private readonly double earthOrbit = 360f / 8766f;
    private double earthProgress = 175f;
    // Moon rotates every ~648hrs and orbits the earth every ~655.728hrs.
    private readonly float moonRotation = 360f / 648f;
    private readonly double moonOrbit = 360f / 655.728f;
    private double moonProgress = 175f;
    // Mars rotates every ~24.6hrs and orbits the sun every ~166488hrs
    private readonly float marsRotation = 360f / 24.6f;
    private readonly double marsOrbit = 360f / 166488f;
    private double marsProgress = 30f;
    // Jupiter rotates every ~9.925hrs and orbits the sun every ~103893.6hrs
    private readonly float jupiterRotation = 360f / 9.925f;
    private readonly double jupiterOrbit = 360f / 103893.6f;
    private double jupiterProgress = 60f;
    // Saturn rotates every ~10.7hrs and orbits the sun every ~258144hrs
    private readonly float saturnRotation = 360f / 10.7f;
    private readonly double saturnOrbit = 360f / 258144f;
    private double saturnProgress = 90f;
    // Uranus rotates every ~17.2hrs and orbits the sun every ~735840hrs (retrograde/contrary to earth)
    private readonly float uranusRotation = 360f / 17.2f;
    private readonly double uranusOrbit = 360f / 735840f;
    private double uranusProgress = 90f;
    // Saturn rotates every ~19.1hrs and orbits the sun every ~1444800hrs
    private readonly float neptuneRotation = 360f / 19.1f;
    private readonly double neptuneOrbit = 360f / 1444800f;
    private double neptuneProgress = 120f;


    /*private float time = 0.0f;
    private float interpolationPeriod = 1f;*/


    void Start()
    {
        sunPosition = Sun.transform.localPosition;
        if (Sun == null || Mercury == null || Venus == null || Earth == null || Mars == null || Jupiter == null || Saturn == null || Uranus == null || Neptune == null)
        {
            orbitActive = false;
            return;
        }

            /* Debug.Log("Earth rotation speed:" + earthRotation);
             Debug.Log("Earth orbit speed:" + earthOrbit);
             Debug.Log("Earth start progress:" + earthProgress */
    }

    // Update is called once per frame
    void Update()
    {

        /*time += Time.deltaTime;
        if(time >= interpolationPeriod)
        {
            Debug.Log("time interpolation");
            time = time - interpolationPeriod;
        }*/

        if(orbitActive) {
            // Rotations
            this.PlanetRotation(Sun, -sunRotation);
            this.PlanetRotation(Mercury, -mercuryRotation);
            this.PlanetRotation(Venus, venusRotation);
            this.PlanetRotation(Earth, -earthRotation);
            this.PlanetRotation(Moon, -moonRotation);
            this.PlanetRotation(Mars, -marsRotation);
            this.PlanetRotation(Jupiter, -jupiterRotation);
            this.PlanetRotation(Saturn, -saturnRotation);
            this.PlanetRotation(Uranus, uranusRotation);
            this.PlanetRotation(Neptune, -neptuneRotation);

            // Orbit
            mercuryProgress = this.updateOrbitalProgress(mercuryProgress, -mercuryOrbit, 360);
            this.OrbitalRotation(Mercury, mercuryProgress, sunPosition);
            venusProgress = this.updateOrbitalProgress(venusProgress, -venusOrbit, 360);
            this.OrbitalRotation(Venus, venusProgress, sunPosition);
            earthProgress = this.updateOrbitalProgress(earthProgress, -earthOrbit, 360);
            this.OrbitalRotation(Earth, earthProgress, sunPosition);
            moonProgress = this.updateOrbitalProgress(moonProgress, -moonOrbit, 360);
            this.OrbitalSateliteRotation(Moon, moonProgress, Earth.transform.position);
            Debug.Log(moonProgress);
            marsProgress = this.updateOrbitalProgress(marsProgress, -marsOrbit, 360);
            this.OrbitalRotation(Mars, marsProgress, sunPosition);
            jupiterProgress = this.updateOrbitalProgress(jupiterProgress, -jupiterOrbit, 360);
            this.OrbitalRotation(Jupiter, jupiterProgress, sunPosition);
            saturnProgress = this.updateOrbitalProgress(saturnProgress, -saturnOrbit, 360);
            this.OrbitalRotation(Saturn, saturnProgress, sunPosition);
            uranusProgress = this.updateOrbitalProgress(uranusProgress, -uranusOrbit, 360);
            this.OrbitalRotation(Uranus, uranusProgress, sunPosition);
            neptuneProgress = this.updateOrbitalProgress(neptuneProgress, -neptuneOrbit, 360);
            this.OrbitalRotation(Neptune, neptuneProgress, sunPosition);
        }
    }

    private void PlanetRotation(GameObject planet, float rotationSpeed)
    {
        planet.transform.Rotate((transform.up * Time.deltaTime * rotationSpeed) * baseSpeed, Space.Self);
    }

    private void OrbitalRotation(GameObject planet, double planetOrbitProgress, Vector3 orbitalBodyLocalPosition)
    {
        EllipseRenderer ellipseData = planet.GetComponentInChildren<EllipseRenderer>();
        Vector2 pos = ellipseData.getEvaluatedEllipse(planetOrbitProgress);
        Vector3 currentPos = planet.transform.position;
        planet.transform.position = new Vector3(pos.x+ orbitalBodyLocalPosition.x, currentPos.y, pos.y+ orbitalBodyLocalPosition.z);
    }
    private void OrbitalSateliteRotation(GameObject planet, double planetOrbitProgress, Vector3 orbitalBodyLocalPosition)
    {
        EllipseRenderer ellipseData = planet.GetComponentInChildren<EllipseRenderer>();
        Vector2 pos = ellipseData.getEvaluatedEllipseMoon(planetOrbitProgress, orbitalBodyLocalPosition);
        Vector3 currentPos = planet.transform.localPosition;
        planet.transform.position = new Vector3(pos.x, currentPos.y, pos.y);
    }

    private double updateOrbitalProgress(double currentProgress, double orbitalSpeed, int segments)
    {
        double tmpOrbitalProgress = currentProgress + ((orbitalSpeed * Time.deltaTime) * baseSpeed);
        tmpOrbitalProgress %= segments;
        return tmpOrbitalProgress;
    }

    public void FasterRotation()
    {
        if (baseSpeed <= -10000 && baseSpeed > -10)
        {
            baseSpeed *= 10;
        }
        else if (baseSpeed == -10)
        {
            baseSpeed = -1;
        }
        else if (baseSpeed == -1)
        {
            baseSpeed = 0;
        }
        else if (baseSpeed == 0)
        {
            baseSpeed = 1;
        }
        else if (baseSpeed == 1)
        {
            baseSpeed = 10;
        }
        else if (baseSpeed >= 10 && baseSpeed < 10000)
        {
            baseSpeed *= 10;
        }
        else if (baseSpeed >= 10000)
        {
            baseSpeed = 10000;
        }
    }

    public void setBaseSpeed(float input)
    {
        baseSpeed = input;
    }

    public void SlowerRotation()
    {
        if(baseSpeed <= 10000 && baseSpeed > 10) {
            baseSpeed /= 10;
        } else if (baseSpeed == 10) {
            baseSpeed = 1;
        } else if (baseSpeed == 1) {
            baseSpeed = 0;
        } else if(baseSpeed == 0) {
            baseSpeed = -1;
        } else if (baseSpeed == -1) {
            baseSpeed = -10;
        } else if (baseSpeed <= -10 && baseSpeed > -10000 ) {
            baseSpeed *= 10;
        } else if (baseSpeed <= -10000){
            baseSpeed = -10000;
        }
    }
}
