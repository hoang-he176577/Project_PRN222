-- Xóa dữ liệu cũ
DELETE FROM [test].[dbo].[notifications];
DELETE FROM [test].[dbo].[attendances];
DELETE FROM [test].[dbo].[scores];
DELETE FROM [test].[dbo].[exams];
DELETE FROM [test].[dbo].[schedules];
DELETE FROM [test].[dbo].[class_members];
DELETE FROM [test].[dbo].[classes];
DELETE FROM [test].[dbo].[users];
DELETE FROM [test].[dbo].[terms];
DELETE FROM [test].[dbo].[subjects];
DELETE FROM [test].[dbo].[rooms];

-- Thêm phòng học
SET IDENTITY_INSERT [test].[dbo].[rooms] ON;
INSERT INTO [test].[dbo].[rooms] (Id, Name, Capacity) VALUES
(1, 'Lecture Hall A1', 100),
(2, 'Lab Room B1', 40),
(3, 'Classroom C1', 50),
(4, 'Seminar Room D1', 30),
(5, 'Physics Lab E1', 35);
SET IDENTITY_INSERT [test].[dbo].[rooms] OFF;

-- Thêm môn học
SET IDENTITY_INSERT [test].[dbo].[subjects] ON;
INSERT INTO [test].[dbo].[subjects] (Id, Name) VALUES
(1, 'Calculus'),
(2, 'Computer Science'),
(3, 'Economics'),
(4, 'Physics'),
(5, 'Psychology'),
(6, 'Chemistry'),
(7, 'Philosophy'),
(8, 'Artificial Intelligence');
SET IDENTITY_INSERT [test].[dbo].[subjects] OFF;

-- Thêm các kỳ học
SET IDENTITY_INSERT [test].[dbo].[terms] ON;
INSERT INTO [test].[dbo].[terms] (Id, Name) VALUES
(1, 'Fall 2025'),
(2, 'Spring 2026');
SET IDENTITY_INSERT [test].[dbo].[terms] OFF;

-- Thêm người dùng (giảng viên và sinh viên)
SET IDENTITY_INSERT [test].[dbo].[users] ON;
INSERT INTO [test].[dbo].[users] (Id, Name, Username, PasswordHash, Email, PhoneNumber, Role, IsDeleted) VALUES
(1, 'Prof. Smith', 'teacher1', 'teacher1', 'smith@example.com', '0987654321', 1, 0),
(2, 'Dr. Johnson', 'drjohnson', 'hashedpass', 'johnson@example.com', '0987654322', 1, 0),
(3, 'Student 1', 'student1', 'student1', 'student1@example.com', '0901234561', 2, 0),
(4, 'Student 2', 'student2', 'student2', 'student2@example.com', '0901234562', 2, 0);
SET IDENTITY_INSERT [test].[dbo].[users] OFF;

-- Thêm lớp học
SET IDENTITY_INSERT [test].[dbo].[classes] ON;
INSERT INTO [test].[dbo].[classes] (Id, Name, TeacherId) VALUES
(1, 'Calculus 101', 1),
(2, 'Computer Science 101', 2);
SET IDENTITY_INSERT [test].[dbo].[classes] OFF;

-- Thêm thành viên vào lớp học
SET IDENTITY_INSERT [test].[dbo].[class_members] ON;
INSERT INTO [test].[dbo].[class_members] (Id, UserId, ClassId) VALUES
(1, 3, 1),
(2, 3, 2),
(3, 4, 1),
(4, 4, 2);
SET IDENTITY_INSERT [test].[dbo].[class_members] OFF;

-- Thêm thời khóa biểu cho ít nhất 2 kỳ học
SET IDENTITY_INSERT [test].[dbo].[schedules] ON;
INSERT INTO [test].[dbo].[schedules] (Id, ClassId, TermId, RoomId, SubjectId, TeacherId, StartDate, EndDate, DaysOfWeek, StudySessions) VALUES
(1, 1, 1, 1, 1, 1, '2025-09-01', '2025-12-15', 'Monday, Wednesday', '1,2'),
(2, 2, 1, 2, 2, 2, '2025-09-02', '2025-12-16', 'Tuesday, Thursday', '2,3'),
(3, 1, 2, 3, 3, 1, '2026-02-01', '2026-05-30', 'Monday, Friday', '2'),
(4, 2, 2, 4, 4, 2, '2026-02-02', '2026-05-31', 'Wednesday', '1');
SET IDENTITY_INSERT [test].[dbo].[schedules] OFF;

-- Thêm lịch thi
SET IDENTITY_INSERT [test].[dbo].[exams] ON;
INSERT INTO [test].[dbo].[exams] (Id, SubjectId, ClassId, ExamDate, StartTime, EndTime, RoomId, TeacherId, TermId) VALUES
(1, 1, 1, '2025-12-20', '09:00:00', '11:00:00', 1, 1, 1),
(2, 2, 2, '2025-12-21', '10:00:00', '12:00:00', 2, 2, 1),
(3, 3, 1, '2026-05-25', '08:00:00', '10:00:00', 3, 1, 2),
(4, 4, 2, '2026-05-26', '10:30:00', '12:30:00', 4, 2, 2);
SET IDENTITY_INSERT [test].[dbo].[exams] OFF;

-- Thêm điểm số
SET IDENTITY_INSERT [test].[dbo].[scores] ON;
INSERT INTO [test].[dbo].[scores] (Id, StudentId, SubjectId, ExamId, Value, TermId) VALUES
(1, 3, 1, 1, 85.50, 1),
(2, 4, 1, 1, 92.00, 1),
(3, 3, 2, 2, 78.25, 1),
(4, 4, 2, 2, 88.75, 1),
(5, 3, 3, 3, 90.00, 2),
(6, 4, 4, 4, 82.50, 2);
SET IDENTITY_INSERT [test].[dbo].[scores] OFF;
-- Thêm điểm 
SET IDENTITY_INSERT [test].[dbo].[attendances] ON;
INSERT INTO [test].[dbo].[attendances] (Id, StudentId, ScheduleId, Status, Date) VALUES
(1, 3, 1, 1, '2025-09-06 08:00:00'),
(2, 3, 1, 0, '2025-09-13 08:00:00'),
(3, 3, 2, 2, '2025-09-20 08:00:00');
SET IDENTITY_INSERT [test].[dbo].[attendances] OFF;

-- Thêm thông báo
SET IDENTITY_INSERT [test].[dbo].[notifications] ON;
INSERT INTO [test].[dbo].[notifications] (Id, SenderId, ReceiverId, Message, CreatedAt) VALUES
(1, 1, 3, 'Your Math score has been updated.', '2025-01-01 00:00:00'),
(2, 1, 3, 'Reminder: English exam on 2025-05-17.', '2025-05-10 00:00:00'),
(3, 1, 3, 'Your attendance for Math on 2025-01-13 has been recorded.', '2025-01-13 00:00:00');
SET IDENTITY_INSERT [test].[dbo].[notifications] OFF;
