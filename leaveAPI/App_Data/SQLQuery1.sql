SELECT * FROM [Class] WHERE IsDelete = 0
--UPDATE [Class] SET IsDelete = ISNULL(@ClassSpecialityTeacherID,[ClassSpecialityTeacherID]) WHERE [ClassID]=@ClassID;
UPDATE [Class] SET IsDelete = 1 WHERE [ClassID]=3;


SELECT * FROM [Specialty] WHERE IsDelete = 0
UPDATE [Specialty] SET IsDelete = 1 WHERE [SpecialtyID]=6;