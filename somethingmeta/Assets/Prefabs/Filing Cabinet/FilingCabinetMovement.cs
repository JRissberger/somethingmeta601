using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilingCabinetMovement: MonoBehaviour
{
    public Animator filingCabinet;
    public void MoveFilingCabinet()
    {
        filingCabinet.SetBool("FilingCabinetMovied", true);
    }
}
