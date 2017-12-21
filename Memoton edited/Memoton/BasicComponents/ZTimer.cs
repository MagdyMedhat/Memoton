using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memoton.BasicComponents
{
    public class ZTimer : ZComponent
    {
        int m_ticksElapsed;
        int m_targetTicks;
        bool m_running;

        public ZTimer(int p_targetTicks): base(null)
        {
            this.m_targetTicks = p_targetTicks;
            this.m_running = true;
            m_ticksElapsed = 0;
        }

        /// <summary>
        /// Resets the timer to initial position.
        /// </summary>
        public void Reset()
        {
            m_ticksElapsed = 0;
        }

        /// <summary>
        /// Pauses the timer in its current position.
        /// </summary>
        public void Pause()
        {
            m_running = false;
        }

        /// <summary>
        /// Continues the timer from its previous position.
        /// </summary>
        public void Contine()
        {
            m_running = true;
        }

        /// <summary>
        /// checks if the ticks made has reached target ticks.
        /// </summary>
        public bool IsTimedOut()
        {
            return (m_ticksElapsed >= m_targetTicks);
        }

        /// <summary>
        /// Changes the timer Target clicks.
        /// </summary>
        public void Change(int TargetTicks)
        {
            this.m_targetTicks = TargetTicks;
        }

        public override void Update()
        {
            if (m_running)
            {
                m_ticksElapsed++;
                if (m_ticksElapsed > m_targetTicks)
                    Reset();
            }
        }
    }
}
