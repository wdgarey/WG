using System;

namespace WG.Database.Statements
{
    public abstract class Statement
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public virtual void Execute()
        {

        }

        protected abstract string CreateString();
    }
}
