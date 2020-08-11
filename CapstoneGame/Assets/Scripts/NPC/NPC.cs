﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using Assets.Code.FSM;

namespace Assets.Code.NPCCode
{
    [RequireComponent(typeof(NavMeshAgent), (typeof(FiniteStateMachine)))]
    
    public class NPC: MonoBehaviour
    {
        public Transform target;

        [SerializeField]
        protected NPCPatrolPoints[] patrolPoints;

        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStatemachine;
        public int attackDamage;

        public void Awake()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>(); //this. is not neccessary but leaving for now
            finiteStatemachine = this.GetComponent<FiniteStateMachine>();
            //target = null;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public virtual void Attack(Transform attackTarget)
        {
            PlayerHealth health = attackTarget.GetComponent<PlayerHealth>();
            health.Damage(attackDamage);

            //Set animation here
        }
        public NPCPatrolPoints[] PatrolPoints
        {
            get
            {
                return patrolPoints;
            }
        }
    }
}
