using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiFengToDo.Common.Models
{
    public class BaseDto
    {
        private int id;
        private DateTime createTime;
        private DateTime updateTime;

        public int Id { get => id; set => id = value; }
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        public DateTime UpdateTime { get => updateTime; set => updateTime = value; }
    }
}
