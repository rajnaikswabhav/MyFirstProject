using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmpList = new List<Emp>()
            {
                new Emp { Empno=7839, Ename="KING", Job="PRESIDENT", Hiredate="17-NOV-81", Sal=5000, Deptno=10 },
                new Emp { Empno=7698, Ename="BLAKE", Job="MANAGER", Mgr=7839, Hiredate="1-MAY-81", Sal=2850, Deptno=30 },
                new Emp { Empno=7782, Ename="CLARK", Job="MANAGER", Mgr=7839, Hiredate="9-JUN-81", Sal=2450, Deptno=10 },
                new Emp { Empno=7566, Ename="JONES", Job="MANAGER", Mgr=7839, Hiredate="2-APR-81", Sal=2975, Deptno=20 },
                new Emp { Empno=7654, Ename="MARTIN", Job="SALESMAN", Mgr=7698, Hiredate="28-SEP-81", Sal=1250, Comm=1400, Deptno=30 },
                new Emp { Empno=7499, Ename="ALLEN", Job="SALESMAN", Mgr=7698, Hiredate="20-FEB-81", Sal=1600, Comm=300, Deptno=30 },
                new Emp { Empno=7844, Ename="TURNER", Job="SALESMAN", Mgr=7698, Hiredate="8-SEP-81", Sal=1500, Comm=0, Deptno=30 },
                new Emp { Empno=7900, Ename="JAMES", Job="CLERK", Mgr=7698, Hiredate="3-DEC-81", Sal=950, Deptno=30 },
                new Emp { Empno=7521, Ename="WARD", Job="SALESMAN", Mgr=7698, Hiredate="22-FEB-81", Sal=1250, Comm=500, Deptno=30 },
                new Emp { Empno=7902, Ename="FORD", Job="ANALYST", Mgr=7566, Hiredate="3-DEC-81", Sal=3000,  Deptno=20 },
                new Emp { Empno=7369, Ename="SMITH", Job="CLERK", Mgr=7902, Hiredate="17-DEC-80", Sal=800, Deptno=20 },
                new Emp { Empno=7788, Ename="SCOTT", Job="ANALYST", Mgr=7566, Hiredate="09-DEC-82", Sal=3000, Deptno=20 },
                new Emp { Empno=7876, Ename="ADAMS", Job="CLERK", Mgr=7788, Hiredate="12-JAN-83", Sal=1100, Deptno=20 },
                new Emp { Empno=7934, Ename="MILLER", Job="CLERK", Mgr=7782, Hiredate="23-JAN-82", Sal=1300, Deptno=10 },
            };

            var DeptList = new List<Dept>()
            {
                new Dept { Deptno=10,Dname="ACCOUNTING",Loc="NEW YORK"},
                new Dept { Deptno=20,Dname="RESEARCH",Loc="DALLAS"},
                new Dept { Deptno=30,Dname="SALES",Loc="CHICAGO"},
                new Dept { Deptno=40,Dname="OPERATIONS",Loc="BOSTON"}
            };

            //DeptTenEmp(EmpList);
            //NameStartWithSEmp(EmpList);
            //CommZeroEmp(EmpList);
            //Dept1020Emp(EmpList);
            //Dept10MgrEmp(EmpList);

            //SumDept10Sal(EmpList);

            //CountDept10Emp(EmpList);

            //Top3SalaryEmp(EmpList);

            //var countDeptwise = EmpList.Count(e => e.Deptno).GroupBy(e => e.Deptno);

            //ScottDetails(EmpList);
            //var scottSal = EmpList.Where(e1 => e1.Ename == "SCOTT").Select(e1=>e1.Sal);
            //ConsoleWriteLine(scottSal.);
            // DisplayEmployees(scottSal);
            //var empSalAsScott = EmpList.Where(e => e.Sal == );

            //Inner join(all the employees and there dept Name)
            var innerJoinEmp = EmpList.Join(DeptList,
                                            e => e.Deptno,
                                            d=>d.Deptno,
                                            (e,d)=>
                                            new{
                                                EmpNo=e.Empno,
                                                EName=e.Ename,
                                                DeptNo=e.Deptno,
                                                DName=d.Dname
                                            });

            var leftJoinEmp = DeptList.Join(EmpList,
                                           d => d.Deptno,
                                           e=>e.Deptno,
                                           (d, e) =>
                                           new {
                                               DeptNo = d.Deptno,
                                               EName = e.Ename
                                           });

            var selfJoinEmp = EmpList.Join(EmpList,
                                            e1 => e1.Mgr,
                                            e2 => e2.Empno,
                                            (e1, e2) =>
                                            new {
                                                EName = e1.Ename,
                                                Manager = e2.Ename,
                                                })
                                       .OrderBy(s=>s.Manager);

            var multipleJoinEmp = EmpList.Join(EmpList,
                                            e1 => e1.Mgr,
                                            e2 => e2.Empno,
                                            (e1,e2) =>
                                            new
                                            {
                                                EName = e1.Ename,
                                                Manager = e2.Ename,
                                                DeptNo = e1.Deptno
                                            }).Join(DeptList,
                                                s=>s.DeptNo,
                                                d=>d.Deptno,
                                                (s,d)=>
                                                new
                                                {
                                                    EName=s.EName,
                                                    DName=d.Dname,
                                                    Manager=s.Manager
                                                }
                                            );
                                       
            foreach (var x in innerJoinEmp)
            {
                Console.WriteLine(x.EmpNo + " " + x.EName + " " + x.DeptNo + " " + x.DName );
            }
            Console.WriteLine();

            foreach (var x in leftJoinEmp)
            {
                Console.WriteLine(x.DeptNo + " " + x.EName);
            }
            Console.WriteLine();


            foreach (var x in selfJoinEmp)
            {
                Console.WriteLine(x.EName + " " + x.Manager);
            }
            Console.WriteLine();

            foreach (var x in multipleJoinEmp)
            {
                Console.WriteLine(x.EName + " " + x.DName + " " + x.Manager);
            }
            Console.WriteLine();

        }

        private static void ScottDetails(List<Emp> EmpList)
        {
            //employee name scott details
            var scottDetails = EmpList.Where(e => e.Ename == "SCOTT");
            DisplayEmployees(scottDetails);
        }

        private static void Top3SalaryEmp(List<Emp> EmpList)
        {
            //select top 3 salary earning employees
            var salAscEmp = EmpList.OrderByDescending(e => e.Sal).Take(3);
            DisplayEmployees(salAscEmp);
        }

        private static void CountDept10Emp(List<Emp> EmpList)
        {
            var countDept10Emp = EmpList.Count(e => e.Deptno == 10);
            Console.WriteLine(countDept10Emp);

            Console.WriteLine();
        }

        private static void SumDept10Sal(List<Emp> EmpList)
        {
            //sum of the salary of employees in dept 10(sum)
            var sumSal = EmpList.Sum(e =>
            {
                if (e.Deptno == 10)
                    return e.Sal;
                else
                    return 0;
            });
            Console.WriteLine(sumSal);

            Console.WriteLine();
        }

        private static void Dept10MgrEmp(List<Emp> EmpList)
        {
            //employee in Dept 10 And Manager
            var dept10MgrEmp = EmpList.Where(e => e.Deptno == 10 && e.Job == "MANAGER");
            DisplayEmployees(dept10MgrEmp);
        }

        private static void Dept1020Emp(List<Emp> EmpList)
        {
            //employee in Dept 10 And 20
            var dept1020Emp = EmpList.Where(e => e.Deptno == 10 || e.Deptno == 20);
            DisplayEmployees(dept1020Emp);
        }

        private static void CommZeroEmp(List<Emp> EmpList)
        {
            //all the employees whose comm is 0
            var comm0emp = EmpList.Where(e => e.Comm == 0);
            DisplayEmployees(comm0emp);
        }

        private static void NameStartWithSEmp(List<Emp> EmpList)
        {
            //All the employees name start with s
            var empS = EmpList.Where(e => e.Ename.StartsWith("S"));
            DisplayEmployees(empS);
        }

        private static void DeptTenEmp(List<Emp> EmpList)
        {
            //All Employees in Dept 10
            var deptTenEmp = EmpList.Where(e => e.Deptno == 10);
            DisplayEmployees(deptTenEmp);
        }

        private static void DisplayEmployees(IEnumerable<Emp> elist)
        {
            foreach (var x in elist)
            {
                Console.WriteLine(x.Empno + " " + x.Ename + " " +x.Job + " " + x.Mgr + " " + x.Hiredate + " " + x.Sal + " " + x.Comm + " " + x.Deptno);
            }
            Console.WriteLine();
        }
    }
}
