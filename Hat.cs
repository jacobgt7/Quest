using System;

namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription
        {
            get
            {
                if (this.ShininessLevel > 9)
                {
                    return "blinding";
                }
                else if (this.ShininessLevel > 5)
                {
                    return "bright";
                }
                else if (this.ShininessLevel > 1)
                {
                    return "noticeable";
                }
                else
                {
                    return "dull";
                }
            }
        }
    }
}