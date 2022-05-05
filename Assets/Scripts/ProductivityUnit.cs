using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit // replace MonoBehaviour with Unit
{
    // new variables
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        // start of new code
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
        // end of new code
    }
    public virtual void GoTo(Building target)
    {
        m_Target = target;
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
        if (m_Target != null)
        {
            m_Agent.SetDestination(m_Target.transform.position);
            m_Agent.isStopped = false;
        }
    }

    public virtual void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
        m_Target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }
    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

}
