using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _cashAmount = 0;

    public void AddCash(int count)
    {
        _cashAmount += count;
    }
}
