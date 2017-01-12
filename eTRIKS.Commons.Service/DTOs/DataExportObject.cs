﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eTRIKS.Commons.Core.Domain.Interfaces;
using eTRIKS.Commons.Core.Domain.Model;
using eTRIKS.Commons.Core.Domain.Model.DesignElements;
using eTRIKS.Commons.Core.Domain.Model.DatasetModel.SDTM;

namespace eTRIKS.Commons.Service.DTOs
{
    public class DataExportObject
    {
        public List<SdtmRow> Observations { get; set; }
        public List<SubjectCharacteristic> SubjChars { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Study> Studies { get; set; }
        public List<HumanSubject> Subjects { get; set; }
        //public List<Study> StudiesWithArmsIncluded { get; internal set; }
        public bool IsSubjectIncluded { get; set; }

        public DataExportObject()
        {
            Observations = new List<SdtmRow>();
            SubjChars = new List<SubjectCharacteristic>();
            Visits = new List<Visit>();
            Arms = new List<Arm>();
            Studies = new List<Study>();
        }
       
        public void FilterAndJoin()
        {
            //filter subjects by studies
            if(Arms.Any())
                Subjects = Subjects.FindAll(s => Arms.Select(a => a.Name).Contains(s.StudyArm.Name)).ToList();

            Debug.WriteLine(Subjects.Count," AFTER ARMS");

            //filter subjects by arms
            if(Studies.Any())
                Subjects = Subjects.FindAll(s => Studies.Select(st => st.Name).Contains(s.Study.Name)).ToList();
            Debug.WriteLine(Subjects.Count, " AFTER Studies");

            //filter subjects by subCharacteristics
            if (SubjChars.Any())
            Subjects = Subjects.FindAll(s => SubjChars.Select(sc => sc.SubjectId).Contains(s.Id)).ToList();
            Debug.WriteLine(Subjects.Count, " AFTER SubjChars");

            //filter by visits
            //TODO

            //TODO : WILL RETRIEVE SUBJECTS THAT HAVE SAME UNIQUE IDS ACROSS PROJECTS  (i.e. need to load observations to Mongo with 
            //TODO: DB subjectId
            //filter observations for filtered subjects
            Observations = Observations?.FindAll(o => Subjects.Select(s => s.UniqueSubjectId).Contains(o.USubjId));

            //filter subjects by selected observations
            Subjects = Subjects.FindAll(s => Observations.Select(o => o.USubjId).Contains(s.UniqueSubjectId));
            Debug.WriteLine(Subjects.Count, " AFTER syncing with observations");
        }




        public string GetArmForSubject(string subjectId)
        {
            return Subjects.Find(a => a.Id == subjectId)?.StudyArm.Name;
        }

        public string GetSubjCharacterisiticForSubject(string subjectId, int characteristicId)
        {
            return
                SubjChars.Find(sc => sc.SubjectId == subjectId && sc.CharacteristicObjectId == characteristicId)?
                    .VerbatimValue;
        }

        public string GetStudyForSubject(string subjectId)
        {
            return Studies.Find(s => s.Subjects.Select(j => j.UniqueSubjectId).Contains(subjectId)).Name;
        }

        //public void FillArms(string projectAcc)
        //{
        //    var arms = _armRepository.FindAll(a => a.Studies.All(s => s.Project.Accession == projectAcc)).ToList();
        //    //Apply filter?
        //   Arms = arms;
        //    SubjectArms = _subjectRepository.FindAll(s => s.Study.Project.Accession == projectAcc,
        //        new List<Expression<Func<HumanSubject, object>>>() { s => s.StudyArm }).ToList();
        //    StudyArms = _studyRepository.FindAll(s => s.Project.Accession == projectAcc,
        //        new List<Expression<Func<Study, object>>>() { s => s.Arms }).ToList();
        //}
    }


}
