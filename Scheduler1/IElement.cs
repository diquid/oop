using System.Windows.Forms;

namespace Scheduler1
{
    public interface IElement
    {
        Control Build(int size);
    }
}