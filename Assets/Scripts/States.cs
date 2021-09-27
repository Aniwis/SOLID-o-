using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public abstract class States
    {
        public virtual IEnumerator Normal()
        {
            yield break;

        }

        public virtual IEnumerator Scared()
        {
            
            {
                yield break;
            }
        }
    }
}
