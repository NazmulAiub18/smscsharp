using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DataAccess
    {
        public static SchoolDataContext mdc = new SchoolDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\annafi\Desktop\Update\Data Access Layer\SchoolManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public void InsertStudent(string Name, int Class, string FaN, string MoN, string DoB, string Address, string Email, string Pass, string CPass, string Gender, string Location,int Id)
        {
            Student u = new Student();
            u.Id = Id;
            u.Name = Name;
            u.Class = Class;
            u.FaN = FaN;
            u.MoN = MoN;
            u.DoB = DoB;
            u.Address = Address;
            u.Email = Email;
            u.Pass = Pass;
            u.Gender = Gender;
            u.Pic = Location;
            u.Status = "P";
            mdc.Students.InsertOnSubmit(u);
            mdc.SubmitChanges();
        }

        public void InsertTeacher(string Name, string CA, string PA, string Nationality, string DoB, string MS, string Email, string SSC, string HSC, string Undergraduate, string Graduate, string Pass, string CPass, string Gender, string Location,int Id)
        {
            Teacher t = new Teacher();
            t.Id = Id;
            t.Name = Name;
            t.CA = CA;
            t.PA = PA;
            t.Nationality = Nationality;
            t.DoB = DoB;
            t.MS = MS;
            t.Email = Email;
            t.SSC = SSC;
            t.HSC = HSC;
            t.Undergraduate = Undergraduate;
            t.Graduate = Graduate;
            t.Pass = Pass;
            t.Gender = Gender;
            t.Pic = Location;
            t.Status = "P";
            mdc.Teachers.InsertOnSubmit(t);
            mdc.SubmitChanges();

        }

        public bool InsertInAll(string Pass,string CPass, string Email,string Type)
        {
            All a = new All();
            if (Pass == CPass)
            {
                a.Pass = Pass;
                a.Email = Email;
                a.Status = "P";
                a.Type = Type;
                mdc.Alls.InsertOnSubmit(a);
                mdc.SubmitChanges();
                return true;
            }
            else { return false; }


        }

        public int GetId(string Email)
        {
            var record = from a in mdc.Alls
                         where a.Email == Email
                         select a.Id;
            return record.First();
        }

        public string Validation(int Id,string Pass)
        {
            try
            {
                var record = from a in mdc.Alls
                             where a.Id == Id
                             where a.Pass == Pass
                             select a.Status;
                return record.First();
            }
            catch
            { return null; }
        }

        public string ToGUI(int Id, string Pass)
        {
            var record = from a in mdc.Alls
                         where a.Id == Id
                         where a.Pass == Pass
                         select a.Type;
            return record.First();
        }

        public List<object> GetStudentList()
        {
            var x = from a in mdc.Students
                    where a.Status != "A"
                    select a;
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        //public byte[] GetImage(int Id)
        //{
        //    var i = from a in mdc.Students
        //            where a.Id == Id
        //            select a.Pic;
        //    MemoryStream picc = new MemoryStream(i);
        //}

        public List<object> SearchStudentById(int Id)
        {
            var x = from a in mdc.Students
                    where a.Id==Id
                    select a;
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public void ApproveStudent(int id)
        {
            var x = from a in mdc.Students
                    where a.Id == id
                    select a;
            Student st = x.First();
            st.Status = "A";
            mdc.SubmitChanges();

            var y = from a in mdc.Alls
                    where a.Id == id
                    select a;
            All q = y.First();
            q.Status = "A";
            mdc.SubmitChanges();
        }

        public void RejectStudent(int id)
        {
            var x = from a in mdc.Students
                    where a.Id == id
                    select a;
            Student st = x.First();
            st.Status = "R";
            mdc.SubmitChanges();

            var y = from a in mdc.Alls
                    where a.Id == id
                    select a;
            All q = y.First();
            q.Status = "R";
            mdc.SubmitChanges();
        }

        public List<object> GetTeacherList()
        {
            var x = from a in mdc.Teachers
                    where a.Status != "A"
                    select a;
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public List<object> SearchTeacherById(int Id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == Id
                    select a;
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public void ApproveTeacher(int id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == id
                    select a;
            Teacher te = x.First();
            te.Status = "A";
            mdc.SubmitChanges();

            var y = from a in mdc.Alls
                    where a.Id == id
                    select a;
            All q = y.First();
            q.Status = "A";
            mdc.SubmitChanges();
        }

        public void RejectTeacher(int id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == id
                    select a;
            Teacher te = x.First();
            te.Status = "R";
            mdc.SubmitChanges();

            var y = from a in mdc.Alls
                    where a.Id == id
                    select a;
            All q = y.First();
            q.Status = "R";
            mdc.SubmitChanges();
        }

        public List<object> GetAllTeacherName()
        {
            var x = from a in mdc.Teachers
                    where a.Status == "A"
                    select a.Name;
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public string AddAssign(string Subject, string TeacherName,string Class)
        {
            if (Class == "1")
            {
                try
                {
                    ClassOne a = new ClassOne();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassOnes.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }

            else if (Class == "2")
            {
                try
                {
                    ClassTwo a = new ClassTwo();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassTwos.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "3")
            {
                try
                {
                    ClassThree a = new ClassThree();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassThrees.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "4")
            {
                try
                {
                    ClassFour a = new ClassFour();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassFours.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "5")
            {
                try
                {
                    ClassFive a = new ClassFive();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassFives.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "6")
            {
                try
                {
                    ClassCoy a = new ClassCoy();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassCoys.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "7")
            {
                try
                {
                    ClassSeven a = new ClassSeven();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassSevens.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "8")
            {
                try
                {
                    ClassEight a = new ClassEight();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassEights.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "9")
            {
                try
                {
                    ClassNine a = new ClassNine();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassNines.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            else if (Class == "10")
            {
                try
                {
                    ClassTen a = new ClassTen();
                    a.Subject = Subject;
                    a.TeacherName = TeacherName;
                    mdc.ClassTens.InsertOnSubmit(a);
                    mdc.SubmitChanges();
                    return "Subject Added and Teacher Assigned SuccessFull !!";
                }
                catch
                {
                    return "Subject Already Exists !!";
                }
            }
            return "Hi";
        }

        public string SendNoticeToTeacher(string TeacherName, string Subject, string Notice)
        {
            TeacherNotice a = new TeacherNotice();
            a.Subject = Subject;
            a.TeacherName = TeacherName;
            a.Notice = Notice;
            mdc.TeacherNotices.InsertOnSubmit(a);
            mdc.SubmitChanges();
            return "Notice SuccesFully Sent To " + TeacherName;
        }

        public void ChangePassword(int id,string pass,string type)
        {
            if (type == "S")
            {
                var x = from a in mdc.Students
                        where a.Id == id
                        select a;
                Student st = x.First();
                st.Pass = pass;
                mdc.SubmitChanges();
            }
            else if (type == "T")
            {
                var x = from a in mdc.Teachers
                        where a.Id == id
                        select a;
                Teacher te = x.First();
                te.Pass = pass;
                mdc.SubmitChanges();
            }
            else if (type == "A")
            {
                var x = from a in mdc.Admins
                        where a.Id == id
                        select a;
                Admin ad = x.First();
                ad.Pass = pass;
                mdc.SubmitChanges();
            }
            var y = from a in mdc.Alls
                    where a.Id == id
                    select a;
            All q = y.First();
            q.Pass = pass;
            mdc.SubmitChanges();
        }

        public string GetTeacherNameById(string id)
        {
            var record = from a in mdc.Teachers
                         where a.Id == int.Parse(id)
                         select a.Name;
            return record.First();
        }

        public List<object> GetSubjectOfTeacherByClass(string Class,string TeacherName)
        {
            if (Class == "1")
            {
                try
                {
                    var x = from a in mdc.ClassOnes
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "2")
            {
                try
                {
                    var x = from a in mdc.ClassTwos
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "3")
            {
                try
                {
                    var x = from a in mdc.ClassThrees
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "4")
            {
                try
                {
                    var x = from a in mdc.ClassFours
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "5")
            {
                try
                {
                    var x = from a in mdc.ClassFives
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "6")
            {
                try
                {
                    var x = from a in mdc.ClassCoys
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "7")
            {
                try
                {
                    var x = from a in mdc.ClassSevens
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "8")
            {
                try
                {
                    var x = from a in mdc.ClassEights
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "9")
            {
                try
                {
                    var x = from a in mdc.ClassNines
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "10")
            {
                try
                {
                    var x = from a in mdc.ClassTens
                            where a.TeacherName == TeacherName
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public List<object> GetAllStudentId(string Class)
        {
            try
            {
                var x = from a in mdc.Students
                        where a.Class == int.Parse(Class)
                        where a.Status == "A"
                        select a.Id.ToString();
                List<object> o = new List<object>();
                o.AddRange(x.ToList());
                return o;
            }
            catch
            {
                return null;
            }
        }

        public string GetStudentNameById(string id)
        {
            try
            {
                var record = from a in mdc.Students
                             where a.Id == int.Parse(id)
                             select a.Name;
                return record.First();
            }
            catch
            {
                return null;
            }
        }

        public string GetFirstTermMark(string Cls, string Sub, string Std)
        {
            try
            {
                var record = from a in mdc.Results
                             where a.StdId == Std
                             select a;

                var s = from b in record
                        where b.Class == Cls && b.Subject == Sub
                        select b;
                return s.First().First.ToString();
            }
            catch
            {
                return "Not Given Yet";
            }
        }
        public string GetSecondTermMark(string Cls, string Sub, string Std)
        {
            try
            {
                var record = from a in mdc.Results
                             where a.StdId == Std
                             select a;

                var s = from b in record
                        where b.Class == Cls && b.Subject == Sub
                        select b;
                return s.First().Second.ToString();
            }
            catch
            {
                return "Not Given Yet";
            }
        }
        public string GetFinalTermMark(string Cls, string Sub, string Std)
        {
            try
            {
                var record = from a in mdc.Results
                             where a.StdId == Std
                             select a;

                var s = from b in record
                        where b.Class == Cls && b.Subject == Sub
                        select b;
                return s.First().Final.ToString();
            }
            catch
            {
                return "Not Given Yet";
            }
        }

        public string GetResultValidation(string Cls,string Sub,string Std)
        {
            try
            {
                var record = from a in mdc.Results
                             where a.StdId==Std
                             select a;

                var s = from b in record
                        where b.Class == Cls && b.Subject == Sub
                        select b;
                return s.First().Subject.ToString();
            }
            catch
            {
                return "false";
            }
        }

        public void InsertInResult(string Class, string Subject, string StdId,string First,string Second,string Final)
        {
            Result u = new Result();
            u.Class = Class;
            u.Subject = Subject;
            u.StdId = StdId;
            u.First = First;
            u.Second = Second;
            u.Final = Final;
            mdc.Results.InsertOnSubmit(u);
            mdc.SubmitChanges();
        }

        public void UpdateInResult(string Cls, string Sub, string Std, string First, string Second, string Final)
        {
            var record = from a in mdc.Results
                         where a.StdId == Std
                         select a;

            var s = from b in record
                    where b.Class == Cls && b.Subject == Sub
                    select b;
            //return s.First().Subject.ToString();
            Result u = s.First();
            u.First = First;
            u.Second = Second;
            u.Final = Final;
            mdc.SubmitChanges();
        }

        public void InsertStudentNote(string Class,string Subject, string Location)
        {
            StudentNote a = new StudentNote();
            a.Class = Class;
            a.Subject = Subject;
            a.File = Location;
            mdc.StudentNotes.InsertOnSubmit(a);
            mdc.SubmitChanges();
        }

        public void InsertStudentNotice(string Class, string Subject, string Reason,string Notice)
        {
            StudentNotice a = new StudentNotice();
            a.Class = Class;
            a.Subject = Subject;
            a.Reason = Reason;
            a.Notice = Notice;
            mdc.StudentNotices.InsertOnSubmit(a);
            mdc.SubmitChanges();
        }

        public List<object> GetTeacherNotificationList(string TeacherName)
        {
            var x = from a in mdc.TeacherNotices
                    where a.TeacherName == TeacherName
                    select new { a.Subject, a.Notice };
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public string GetTCA(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.CA;
            return x.First();
        }
        public string GetTPA(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.PA;
            return x.First();
        }
        public string GetTEmail(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Email;
            return x.First();
        }
        public string GetTNationality(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Nationality;
            return x.First();
        }
        public string GetTMS(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.MS;
            return x.First();
        }
        public string GetTSSC(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.SSC;
            return x.First();
        }
        public string GetTHSC(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.HSC;
            return x.First();
        }
        public string GetTGender(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Gender;
            return x.First();
        }
        public string GetTUnder(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Undergraduate;
            return x.First();
        }
        public string GetTGrade(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Graduate;
            return x.First();
        }
        public string GetTImage(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Pic;
            return x.First();
        }
        public string GetTDoB(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.DoB;
            return x.First();
        }
        public string GetTName(string id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == int.Parse(id)
                    select a.Name;
            return x.First();
        }

        public void UpdateTeacher(string Name, string CA, string PA, string Nationality, string DoB, string MS, string Email, string SSC, string HSC, string Undergraduate, string Graduate, string Location, int Id)
        {
            var x = from a in mdc.Teachers
                    where a.Id == Id
                    select a;
            Teacher t = x.First();
            t.Name = Name;
            t.CA = CA;
            t.PA = PA;
            t.Nationality = Nationality;
            t.DoB = DoB;
            t.MS = MS;
            t.Email = Email;
            t.SSC = SSC;
            t.HSC = HSC;
            t.Undergraduate = Undergraduate;
            t.Graduate = Graduate;
            t.Pic = Location;

            mdc.SubmitChanges();
        }

        public string GetSName(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Name;
            return x.First();
        }
        public string GetSClass(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Class;
            return x.First().ToString();
        }
        public string GetSFName(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.FaN;
            return x.First();
        }
        public string GetSMName(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.MoN;
            return x.First();
        }
        public string GetSDoB(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.DoB;
            return x.First();
        }
        public string GetSAdd(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Address;
            return x.First();
        }
        public string GetSMail(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Email;
            return x.First();
        }
        public string GetSGender(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Gender;
            return x.First();
        }
        public string GetSImage(string id)
        {
            var x = from a in mdc.Students
                    where a.Id == int.Parse(id)
                    select a.Pic;
            return x.First();
        }

        public void UpdateStudent(string Name, string FaN, string MoN, string DoB, string Address, string Email, string Location, int Id)
        {
            var x = from a in mdc.Students
                    where a.Id == Id
                    select a;
            Student u = x.First();
            u.Name = Name;
            u.FaN = FaN;
            u.MoN = MoN;
            u.DoB = DoB;
            u.Address = Address;
            u.Email = Email;
            u.Pic = Location;

            mdc.SubmitChanges();
        }

        public List<object> GetStudentNotice(string Class,string Subject)
        {
            var x = from a in mdc.StudentNotices
                    where a.Class == Class && a.Subject == Subject
                    select new { a.Reason, a.Notice };
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public List<object> GetSubjectOfStudentByClass(string Class)
        {
            if (Class == "1")
            {
                try
                {
                    var x = from a in mdc.ClassOnes
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "2")
            {
                try
                {
                    var x = from a in mdc.ClassTwos
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "3")
            {
                try
                {
                    var x = from a in mdc.ClassThrees
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "4")
            {
                try
                {
                    var x = from a in mdc.ClassFours
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "5")
            {
                try
                {
                    var x = from a in mdc.ClassFives
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "6")
            {
                try
                {
                    var x = from a in mdc.ClassCoys
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "7")
            {
                try
                {
                    var x = from a in mdc.ClassSevens
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "8")
            {
                try
                {
                    var x = from a in mdc.ClassEights
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "9")
            {
                try
                {
                    var x = from a in mdc.ClassNines
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }
            else if (Class == "10")
            {
                try
                {
                    var x = from a in mdc.ClassTens
                            select a.Subject;
                    List<object> o = new List<object>();
                    o.AddRange(x.ToList());
                    return o;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public List<object> GetStudentNote(string Class, string Subject)
        {
            var x = from a in mdc.StudentNotes
                    where a.Class == Class && a.Subject == Subject
                    select new { a.Id, a.File };
            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

    }
}
