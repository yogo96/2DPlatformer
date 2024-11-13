using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private int _value;
   [SerializeField] private int _maxValue = 100;
   
   private int _minValue = 0;

   private void Awake()
   {
      Reset();
   }

   public int GetValue()
   {
      return _value;
   }

   public void AddValue(int count)
   {
      if (count <= _minValue)
         return;

      _value = Mathf.Clamp(_value + count, _minValue, _maxValue);
   }

   public void TakeDamage(int value)
   {
      if (value <= _minValue)
         return;
      
      _value = Mathf.Clamp(_value - value, _minValue, _maxValue);
   }

   public void Reset()
   {
      _value = _maxValue;
   }
}
