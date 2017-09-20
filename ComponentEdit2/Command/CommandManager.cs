using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentEdit2
{
    public class CommandManager
    {
        public List<Command> listUndo;//重做的命令列表
        public List<Command> listRedo;//恢复的命令列表

        private int countUndo = -1;                         //-1代表的是无限步

        public CommandManager()
        {
            countUndo = 20;
            listUndo = new List<Command>();
            listRedo = new List<Command>();
        }

        /// <summary>
        /// 执行新操作
        /// </summary>
        /// <param name="cmd">命令</param>
        public void ExecuteCommand(Command cmd)
        {
            cmd.Execute();

            listUndo.Add(cmd);

            //如果可撤销步骤不为无限步，并且listUndo的数量大于了可以撤销的步骤就删除最早添加的命令
            if(countUndo != -1 && listUndo.Count > countUndo)
            {
                listUndo.RemoveAt(0);
            }
            //执行新的操作后，就没有了恢复的命令
            listRedo.Clear();
        }

        /// <summary>
        /// 执行撤销操作
        /// </summary>
        public void UndoCommand()
        {
            if(listUndo.Count <= 0)
            {
                return;
            }

            Command cmd = listUndo.Last<Command>();
            cmd.Undo();

            listUndo.Remove(cmd);
            listRedo.Add(cmd);
        }

        /// <summary>
        /// 执行恢复操作
        /// </summary>
        public void RedoCommand()
        {
            if(listRedo.Count <= 0)
            {
                return;
            }

            Command cmd = listRedo.Last<Command>();
            cmd.Execute();

            listRedo.Remove(cmd);
            listUndo.Add(cmd);
        }
    }
}
