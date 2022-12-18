using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_6_OOP
{
    public class Observable_Node : Folder
    {
        public Observable_Node(int folder_sizee) : base(folder_sizee)
        {
        }
        List<CShape> observers;

        public void add_observer(CShape smth)
        {
            observers.Add(smth);
        }

        public void activate_observers()
        {
            foreach (var observer in observers)
                observer.activate();
        }
    }

    public class Observable_Cshape : TreeNode
    {
        List<TreeNode> observers;

        public void add_observer(TreeNode smth)
        {
            observers.Add(smth);
        }

        public void activate_observers()
        {
            foreach (var observer in observers)
                observer.BackColor = Color.Blue;
        } 
    }

    public class observer_Tree : Folder
    {
        public observer_Tree(int folder_sizee) : base(folder_sizee)
        {
        }

        public void update(TreeNode tn, CShape smth)
        {
            if(smth is Folder)
            {
               for(int i=0;i<(smth as Folder).folder_size; i++)
               {
                    TreeNode tnn = new TreeNode();
                    (smth as observer_Tree).update(tnn, (smth as Folder).get_object(i));
                    tn.Nodes.Add(tnn);
               }
            }
        }
    }






    public class Observable_obj
    {
        List<CShape> observers;

        public void add_observer(CShape smth)
        {
            observers.Add(smth);
        }

        public void move_observers(int dx, int dy)
        {
            foreach (var observer in observers)
                observer.move(dx,dy);
        }
    }


}
