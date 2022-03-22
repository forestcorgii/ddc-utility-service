Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports hrms_api_service.IInterface
Imports Newtonsoft.Json

Namespace Manager
    Namespace API
        Public Class HRMS
            Private Client As New HttpClient

            'Private apiurl As String = "" '"http://idcsi-officesuites.com:8080/hrms/api.php"
            Public What As String = "getinfo"
            Public Field As String = "acctg"
            Public Search As String = ""
            Public APIToken As String = "IUQ0PAI7AI3D162IOKJH"
            Public Url As String

            Public IsUsable As Boolean

            Sub New()

                Client = New HttpClient
                Client.Timeout = TimeSpan.FromSeconds(10)
            End Sub


            Public Async Function GetEmployeeFromServer(idno As String) As Task(Of IEmployee)
                Try
                    Dim dicc As New Dictionary(Of String, String)
                    dicc.Add("idno", idno)
                    dicc.Add("what", what)
                    dicc.Add("field", "acctg")
                    dicc.Add("search", search)
                    dicc.Add("apitoken", apitoken)
                    Dim content As New FormUrlEncodedContent(dicc)

                    Dim response As HttpResponseMessage = Await Client.PostAsync(String.Format("{0}", Url), content)

                    Dim responseString As String = Await response.Content.ReadAsStringAsync()
                    Dim employee As ResponseArgument = JsonConvert.DeserializeObject(Of ResponseArgument)(responseString)
                    Return employee.message(0)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    'MessageBox.Show(ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Return Nothing
            End Function

            Public Class ResponseArgument
                Public message As List(Of MessageArgument)
                Public code As String

                Public Class MessageArgument
                    Implements IEmployee

                    Public Property idno As String Implements IEmployee.idno
                    Public Property last_name As String Implements IEmployee.last_name
                    Public Property first_name As String Implements IEmployee.first_name
                    Public Property middle_name As String Implements IEmployee.middle_name
                    Public Property tin As String Implements IEmployee.tin
                    Public Property department As String Implements IEmployee.department
                    Public Property bank_name As String Implements IEmployee.bank_name
                    Public Property bank_category As String Implements IEmployee.bank_category
                    Public Property account_number As String Implements IEmployee.account_number
                    Public Property card_number As String Implements IEmployee.card_number
                    Public Property payroll_code As String Implements IEmployee.payroll_code
                    Public Property jobcode As String Implements IEmployee.jobcode


                    Public Property job_job_company As String Implements IEmployee.job_job_company
                    Public Property job_job_title As String Implements IEmployee.job_job_title
                    Public Property sss As String Implements IEmployee.sss
                    Public Property philhealth As String Implements IEmployee.philhealth
                    Public Property pagibig As String Implements IEmployee.pagibig
                    Public Property heads_idno As String Implements IEmployee.heads_idno
                    Public Property divisions As String Implements IEmployee.divisions
                    Public Property jobrole As String Implements IEmployee.jobrole
                    Public Property job_location As String Implements IEmployee.job_location
                    Public Property employment_status As String Implements IEmployee.employment_status
                    Public Property job_category As String Implements IEmployee.job_category
                    Public Property leave_replenishment_date As String Implements IEmployee.leave_replenishment_date
                    Public Property joined_date As String Implements IEmployee.joined_date
                    Public Property emp_con_start_date As String Implements IEmployee.emp_con_start_date
                    Public Property job_remarks As String Implements IEmployee.job_remarks
                    Public Property jobnote As String Implements IEmployee.jobnote
                    Public Property effectivity_date As String Implements IEmployee.effectivity_date
                    Public Property rate As String Implements IEmployee.rate
                    Public Property status As String Implements IEmployee.status
                    Public Property remarks_salary As String Implements IEmployee.remarks_salary
                    Public Property atm_status As String Implements IEmployee.atm_status
                    Public Property timesheet_guide_remarks As String Implements IEmployee.timesheet_guide_remarks
                    Public Property work_status As String Implements IEmployee.work_status
                    Public Property ot_flag As String Implements IEmployee.ot_flag
                    Public Property nd_flag As String Implements IEmployee.nd_flag
                    Public Property allowance_flag As String Implements IEmployee.allowance_flag
                    Public Property in_flag As String Implements IEmployee.in_flag


                End Class
            End Class

        End Class
    End Namespace
End Namespace
