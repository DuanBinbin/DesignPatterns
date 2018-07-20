using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPattern
{
    /// <summary>
    /// 功能实现者
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPart1();
        public abstract void BuildPart2();
    }
}
