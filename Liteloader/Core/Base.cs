using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liteloader.Core
{
    public class Base : Form
    {
        internal void CallFunc(Action action)
        {
            Invoke(action);
        }

        internal async virtual Task CallSyncFunc(object sender, Action func)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            var text = btn.Text;
            btn.Text = "...";
            await Task.Run(() =>
            {
                try
                {
                    func.Invoke();
                }
                catch (Exception ex)
                {
                    CallFunc(() => MessageBox.Show(ex.Message));
                }
            });

            btn.Text = text;
            btn.Enabled = true;
        }

    }
}
