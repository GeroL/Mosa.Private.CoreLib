﻿using System.Collections.Generic;
using System.Linq;

using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Mosa.Build.Tasks
{
    public class GetMosaProject : Task
    {
        private List<ITaskItem> projectFiles = new List<ITaskItem>();
        private List<ITaskItem> mosaProjectFiles = new List<ITaskItem>();

        [Required]
        public ITaskItem[] ProjectFiles
        {
            set
            {
                if (value != null)
                    projectFiles = value.ToList();
            }
            get { return projectFiles?.ToArray(); }
        }

        public string Configuration { get; set; }

        public string Platform { get; set; }

        public string TargetFramework { get; set; }

        [Output]
        public ITaskItem[] MosaProjectFiles
        {
            set
            {
                if (value != null)
                {
                    mosaProjectFiles = value.ToList();
                }
            }
            get { return mosaProjectFiles?.ToArray(); }
        }


        public override bool Execute()
        {
            var properties = new Dictionary<string, string>
            {
              { "Configuration", "$(Configuration)" },
              { "Platform", "$(Platform)" },
              { "TargetFramework", "$(TargetFramework)" }
            };

            Log.LogMessage(MessageImportance.High, "Configuration : {0}", Configuration);
            Log.LogMessage(MessageImportance.High, "Platform : {0}", Platform);
            Log.LogMessage(MessageImportance.High, "TargetFramework : {0}", TargetFramework);

            List<ITaskItem> pList = ProjectFiles.ToList();
            List<ITaskItem> mosaList = new List<ITaskItem>();
            foreach (var pItem in pList)
            {
                // Load the project into a separate project collection so
                // we don't get a redundant-project-load error.
                var collection = new ProjectCollection(properties);
                var project = collection.LoadProject(pItem.ItemSpec);
                ProjectProperty pp = project.Properties.Where(p => p.Name == "MosaProject" && p.EvaluatedValue == "true").FirstOrDefault();
                if (pp != null)
                {
                    mosaList.Add(pItem);
                }
            }

            mosaProjectFiles = mosaList;

            return true;
        }

    }

}