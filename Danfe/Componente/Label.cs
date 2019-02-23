using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danfe.Componente
{
    /// <summary>
    /// Calsse de label - Rótulo
    /// </summary>
    public class Label
    {
        public string TextLabel { get; set; }
        public string Font { get; set; }
        public int AlignHorizontal { get; set; }
        public int AlignVertical { get; set; }
        public bool Bold { get; set; } = false;
        public bool Italic { get; set; } = false;
        public float Size { get; set; } = 6f;
    }
}
