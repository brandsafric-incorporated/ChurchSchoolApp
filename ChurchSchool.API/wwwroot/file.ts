//export class Course {
//    public Name: string;
//    public Description: string;
//    public isActive: boolean;
//    public CurrentConfiguration: CourseConfiguration;
//}

//export class CourseConfiguration  {
//    public CourseId: String;
//    public IsCurrentConfiguration: boolean;
//    public ConfigCurriculumns: ConfigurationCurriculum[];
//    public EnrollDocuments: CourseDocuments[];
//    public RelatedCourse: Course;
//}

//export class ConfigurationCurriculum  {
//    public ConfigurationId: String;
//    public CurriculumId: String;
//    public IsCurrentConfiguration: boolean;
//    public IsActive: boolean;
//    public StartDate: Date;
//    public FinishDate: Date;
//    public Curriculum: Curriculum;
//    public Configuration: CourseConfiguration;
//}

//export class Curriculum  {
//    public Description: string;
//    public ConfigCurriculumns: ConfigurationCurriculum[];
//    public Curriculum_Subjects: Curriculum_Subject[];
//}

//export class Curriculum_Subject extends BaseEntity {
//    public CurriculumId: String;
//    public SubjectId: String;
//    public Curriculum: Curriculum;
//    public Subject: Subject;
//}

//export class Subject extends BaseEntity {
//    public Name: string;
//    public RelatedProfessors: IEnumerable<ProfessorSubject>;
//}


//export class Course_Subject extends BaseEntity {
//    public ConfigurationCourseId: Guid;
//    public SubjectId: Guid;
//    public CourseConfiguration: CourseConfiguration;
//    public Subject: Subject;
//    public Class: Domain.Entities.CourseClass;
//}