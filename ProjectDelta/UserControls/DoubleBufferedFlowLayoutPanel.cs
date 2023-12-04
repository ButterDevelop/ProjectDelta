using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayoutPanel()
        {
            DoubleBuffered = true;
        }
    }
}
