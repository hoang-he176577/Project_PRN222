-- 1️⃣ Thêm dữ liệu vào bảng Room
INSERT INTO room (RoomName, Capacity) VALUES
('Phòng A101', 40),
('Phòng B202', 50),
('Phòng C303', 35);

-- 2️⃣ Thêm dữ liệu vào bảng Subject
INSERT INTO subject (SubjectName) VALUES
('Toán cao cấp'),
('Lập trình C#'),
('Cấu trúc dữ liệu'),
('Hệ quản trị CSDL');

-- 3️⃣ Thêm dữ liệu vào bảng User (chỉ Admin & Teacher trước)
INSERT INTO "user" (Name, Username, PasswordHash, Email, PhoneNumber, Role, ClassId, IsDeleted) VALUES
('Admin', 'admin', 'hash1', 'admin@example.com', '0901123456', 0, NULL, 0),  -- 0 = Admin
('Thầy A', 'teacherA', 'hash2', 'thayA@example.com', '0912233445', 1, NULL, 0),  -- 1 = Teacher
('Thầy B', 'teacherB', 'hash3', 'thayB@example.com', '0922233445', 1, NULL, 0);  -- 1 = Teacher

-- 4️⃣ Thêm dữ liệu vào bảng Class
INSERT INTO class (ClassName) VALUES
('Khoa học máy tính K22'),
('Công nghệ thông tin K21');

-- 5️⃣ Thêm dữ liệu vào bảng User (Student sau khi có Class)
INSERT INTO "user" (Name, Username, PasswordHash, Email, PhoneNumber, Role, ClassId, IsDeleted) VALUES
('Nguyễn Văn A', 'sinhvienA', 'hash4', 'sinhvienA@example.com', '0934567890', 2, 1, 0),  -- 2 = Student
('Trần Thị B', 'sinhvienB', 'hash5', 'sinhvienB@example.com', '0945678901', 2, 1, 0),
('Lê Văn C', 'sinhvienC', 'hash6', 'sinhvienC@example.com', '0956789012', 2, 2, 0);

-- 6️⃣ Thêm dữ liệu vào bảng Schedule
INSERT INTO schedule (ClassId, RoomId, SubjectId, TeacherId, StartDate, EndDate, DaysOfWeek, StudySessions, CreatedAt, UpdatedAt) VALUES
(1, 1, 1, 2, '2025-03-01', '2025-06-01', 'Monday,Wednesday', '1,2', GETDATE(), GETDATE()),
(1, 2, 2, 3, '2025-03-02', '2025-06-02', 'Tuesday,Thursday', '2,3', GETDATE(), GETDATE()),
(2, 3, 3, 2, '2025-03-03', '2025-06-03', 'Friday', '1', GETDATE(), GETDATE());

-- 7️⃣ Thêm dữ liệu vào bảng Attendance
INSERT INTO attendance (StudentId, ScheduleId, Status, Date) VALUES
(1, 1, 0, '2025-03-04'),  -- 0 = Present
(2, 1, 2, '2025-03-04'),  -- 2 = Late
(3, 2, 1, '2025-03-05');  -- 1 = Absent

-- 8️⃣ Thêm dữ liệu vào bảng Exam
INSERT INTO exam (SubjectId, ClassId, ExamDate, StartTime, EndTime, RoomId, TeacherId) VALUES
(1, 1, '2025-06-10', '08:00:00', '10:00:00', 1, 2),
(2, 2, '2025-06-12', '13:00:00', '15:00:00', 2, 3);

-- 9️⃣ Thêm dữ liệu vào bảng Score
INSERT INTO score (StudentId, SubjectId, Value, Date) VALUES
(1, 1, 8.5, '2025-06-20'),
(2, 1, 7.0, '2025-06-21'),
(3, 2, 9.0, '2025-06-22');

-- 🔟 Thêm dữ liệu vào bảng Notification
INSERT INTO notification (SenderId, ReceiverId, Message, CreatedAt) VALUES
(1, 2, 'Buổi học ngày mai sẽ có bài kiểm tra.', GETDATE()),
(2, 3, 'Bạn đã vắng mặt buổi học trước.', GETDATE());
