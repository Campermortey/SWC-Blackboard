using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.Models.Interfaces
{
    public interface IGradebookRepository
    {
        GradebookView GetGradebookFor(int courseId);
    }
}
