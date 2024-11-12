using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private int _value;
   [SerializeField] private int _maxValue = 100;

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
      _value += count;
      if (_value > _maxValue)
         _value = _maxValue;
   }

   public void TakeDamage(int value)
   {
      _value -= value;
   }

   public void Reset()
   {
      _value = _maxValue;
   }
}
