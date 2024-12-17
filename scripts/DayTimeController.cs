using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
  private const float secondInDay = 86400f;

  [SerializeField] private Color nightLightColor;
  [SerializeField] private AnimationCurve nightTimeCurve;
  [SerializeField] private Color dayLightColor = Color.white;
  
  float time;
  [SerializeField] private float timeScale = 60f;

  [SerializeField] private Text text;
  [SerializeField] private Light2D globalLight;
  private int days;

  public DayTimeController(float time)
  {
      this.time = time;
  }

  float Hours
  {
      get { return time / 3600f; }
  }

  float Minutes
  {
      get { return time % 3600f / 60f; }
  }

  private void Update()
  {
      time += Time.deltaTime * timeScale;
      int hh = (int)Hours;
      int mm = (int)Minutes;
      text.text = hh.ToString("00" + ":" + mm.ToString("00"));
      float v = nightTimeCurve.Evaluate(Hours);
      Color c = Color.Lerp(dayLightColor, nightLightColor, v);
      globalLight.color = c;
      if (time > secondInDay)
      {
          NextDay();
      }
  }

  private void NextDay()
  {
      time = 0;
      days += 1;
  }
}
