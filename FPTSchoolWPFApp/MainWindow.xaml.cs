using FPTBusiness;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace FPTSchoolWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IGradeRepository gradeRepository;
        public MainWindow()
        {
            InitializeComponent();
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            gradeRepository = new GradeRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGradeList();
            LoadStudentList();
            LoadSubjectList();
        }

        public async void LoadGradeList()
        {
            try
            {
                var gradeList = await gradeRepository.GetAllGrade();
                dtgGrades.ItemsSource = gradeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of grades");
            }
            finally
            {
            }
        }
        public async void LoadSubjectList()
        {
            try
            {
                var subList = await subjectRepository.GetAllSubject();
                cbSubject.ItemsSource = subList;
                dtgSubjects.ItemsSource = subList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of subjects");
            }
        }

        public async void LoadStudentList()
        {
            try
            {
                var specList = await studentRepository.GetAllStudent();
                cbStudent.ItemsSource = specList;
                dtgStudents.ItemsSource = specList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of students");
            }
        }

        //Grade Management
        private async void Save_Click_GradeM(object sender, RoutedEventArgs e)
        {
            try
            {
                Grade grade = new Grade
                {
                    Point = decimal.Parse(txtPoint.Text),
                    DateCreate = DateTime.Now,
                    StudentId = (int)cbStudent.SelectedValue,
                    SubjectId = (int)cbSubject.SelectedValue,
                };
                await gradeRepository.InsertGrade(grade);
                LoadGradeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not add grade");
            }
        }

        private void dtgGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;

                if (dataGrid.SelectedItem == null)
                {
                    RefreshInputGrade();
                    return;
                }

                Grade selected = dataGrid.SelectedItem as Grade;

                if (selected != null)
                {
                    txtGradeID.Text = selected.GradeId.ToString();
                    txtPoint.Text = selected.Point.ToString();
                    cbStudent.SelectedValue = selected.StudentId;
                    cbSubject.SelectedValue = selected.SubjectId;
                }
                else
                {
                    RefreshInputGrade();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error handling selection change");
            }
        }
        private async void Update_Click_GradeM(object sender, RoutedEventArgs e)
        {
            try
            {

                int gradeId = int.Parse(txtGradeID.Text);
                Grade grade = await gradeRepository.GetGradeById(gradeId);
                if (grade != null)
                {
                    grade.DateCreate = DateTime.Now;
                    grade.Point = decimal.Parse(txtPoint.Text);
                    grade.SubjectId = (int)cbSubject.SelectedValue;
                    grade.StudentId = (int)cbStudent.SelectedValue;

                    await gradeRepository.UpdateGrade(grade);
                    LoadGradeList();
                    RefreshInputGrade();
                }
                else
                {
                    MessageBox.Show("Grade not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update grade: " + ex.Message, "Update Error");
            }
        }

        private async void Delete_Click_GradeM(object sender, RoutedEventArgs e)
        {
            try
            {

                int gradeId = int.Parse(txtGradeID.Text);
                Grade grade = await gradeRepository.GetGradeById(gradeId);
                if (grade != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this grade?",
                                                             "Confirm Deleting",
                                                             MessageBoxButton.YesNo,
                                                             MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await gradeRepository.DeleteGrade(grade);
                        MessageBox.Show("This grade deleted successfully.");
                        LoadGradeList();
                        RefreshInputGrade();
                    }
                }
                else
                {
                    MessageBox.Show("Grade not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update grade: " + ex.Message, "Update Error");
            }
        }

        private void RefreshInputGrade()
        {
            txtGradeID.Text = "";
            txtPoint.Text = "";
            cbStudent.SelectedValue = null;
            cbSubject.SelectedValue = null;
        }

        private void Cancel_Click_GradeM(object sender, RoutedEventArgs e)
        {
            RefreshInputGrade();
        }



        //Student Management
        private async void Save_Click_StudentM(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    StudentCode = txtStudentCode.Text,
                    StudentName = txtStudentName.Text,
                };
                await studentRepository.InsertStudent(student);
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not add student");
            }
        }
        private void dtgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;

                if (dataGrid.SelectedItem == null)
                {
                    RefreshInputStudent();
                    return;
                }

                Student selected = dataGrid.SelectedItem as Student;

                if (selected != null)
                {
                    txtStudentId.Text = selected.StudentId.ToString();
                    txtStudentCode.Text = selected.StudentCode;
                    txtStudentName.Text = selected.StudentName;
                }
                else
                {
                    RefreshInputStudent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error handling selection change");
            }
        }
        private async void Update_Click_StudentM(object sender, RoutedEventArgs e)
        {
            try
            {

                int studentId = int.Parse(txtStudentId.Text);
                Student student = await studentRepository.GetStudentById(studentId);
                if (student != null)
                {
                    student.StudentCode = txtStudentCode.Text;
                    student.StudentName = txtStudentName.Text;
                    await studentRepository.UpdateStudent(student);
                    LoadStudentList();
                    RefreshInputStudent();
                }
                else
                {
                    MessageBox.Show("Student not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update student: " + ex.Message, "Update Error");
            }
        }

        private async void Delete_Click_StudentM(object sender, RoutedEventArgs e)
        {
            try
            {

                int studentId = int.Parse(txtStudentId.Text);
                Student student = await studentRepository.GetStudentById(studentId);
                if (student != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this student?",
                                                             "Confirm Deleting",
                                                             MessageBoxButton.YesNo,
                                                             MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await studentRepository.DeleteStudent(student);
                        MessageBox.Show("This student deleted successfully.");
                        LoadStudentList();
                        RefreshInputStudent();
                    }
                }
                else
                {
                    MessageBox.Show("Student not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update student: " + ex.Message, "Update Error");
            }
        }

        private void RefreshInputStudent()
        {
            txtStudentCode.Text = "";
            txtStudentId.Text = "";
            txtStudentName.Text = "";
        }

        private void Cancel_Click_StudentM(object sender, RoutedEventArgs e)
        {
            RefreshInputStudent();
        }
        //Subject Management
        private async void Save_Click_SubjectM(object sender, RoutedEventArgs e)
        {

            try
            {
                Subject subject = new Subject
                {
                    SubjectName = txtSubjectName.Text,
                };
                await subjectRepository.InsertSubject(subject);
                LoadSubjectList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can not add subject");
            }
        }

        private void dtgSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;

                if (dataGrid.SelectedItem == null)
                {
                    RefreshInputSubject();
                    return;
                }

                Subject selected = dataGrid.SelectedItem as Subject;

                if (selected != null)
                {
                    txtSubjectId.Text = selected.SubjectId.ToString();
                    txtSubjectName.Text = selected.SubjectName;
                }
                else
                {
                    RefreshInputSubject();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error handling selection change");
            }
        }

        private async void Update_Click_SubjectM(object sender, RoutedEventArgs e)
        {
            try
            {

                int subjectId = int.Parse(txtSubjectId.Text);
                Subject subject = await subjectRepository.GetSubjectById(subjectId);
                if (subject != null)
                {
                    subject.SubjectName = txtSubjectName.Text;
                    await subjectRepository.UpdateSubject(subject);
                    LoadSubjectList();
                    RefreshInputSubject();
                }
                else
                {
                    MessageBox.Show("Subject not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update subject: " + ex.Message, "Update Error");
            }
        }

        private async void Delete_Click_SubjectM(object sender, RoutedEventArgs e)
        {
            try
            {

                int subjectId = int.Parse(txtSubjectId.Text);
                Subject subject = await subjectRepository.GetSubjectById(subjectId);
                if (subject != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this subject?",
                                                             "Confirm Deleting",
                                                             MessageBoxButton.YesNo,
                                                             MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await subjectRepository.DeleteSubject(subject);
                        MessageBox.Show("This subject deleted successfully.");
                        LoadSubjectList();
                        RefreshInputSubject();
                    }
                }
                else
                {
                    MessageBox.Show("Subject not found.", "Update Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update subject: " + ex.Message, "Update Error");
            }
        }

        private void RefreshInputSubject()
        {
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
        }

        private void Cancel_Click_SubjectM(object sender, RoutedEventArgs e)
        {
            RefreshInputSubject();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}