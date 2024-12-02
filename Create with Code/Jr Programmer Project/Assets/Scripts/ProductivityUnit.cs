using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 4; 

    protected override void BuildingInRange()
    {
        if(m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
        
    }
    public override void GoTo(Building target)
    {
        ResetProductivity(); // Call your method
        base.GoTo(target);  // run method from base class
    }

    
    public override void GoTo(Vector3 position)
    {
        ResetProductivity(); // Call your method
        base.GoTo(position);  // run method from base class
    }

    void ResetProductivity()
    {
        if (m_CurrentPile !=null){
            m_CurrentPile.ProductionSpeed /=ProductivityMultiplier;
            m_CurrentPile =null;
        }
    }
}
