using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Command
{
    public abstract class BaseCommand
    {
        public BaseCommand()
        {

        }

        public abstract void Execute(IReceiver receiver);

    }
}
