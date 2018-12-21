using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hhi_local {
    public static class HHI_Forms {
        public static Form_Main GetMainFrame() {
            if (tMainFrame == null) {
                tMainFrame = new Form_Main();
            }
            return tMainFrame;
        }
        private static Form_Main tMainFrame = null;
    }
}
