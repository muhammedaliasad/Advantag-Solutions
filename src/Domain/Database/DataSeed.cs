using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

public static class DataSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Fixed timestamp for all seeded data to prevent migration issues
        var seedTimestamp = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        // Seed sample dropdowns for keys (5 entries per key)
        modelBuilder.Entity<Dropdown>().HasData(
            // BusinessUnit (1-5)
            new Dropdown { Id = 1, Key = DropdownKeys.BusinessUnit, Label = "Business Unit 1", Value = "BU1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 2, Key = DropdownKeys.BusinessUnit, Label = "Business Unit 2", Value = "BU2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 3, Key = DropdownKeys.BusinessUnit, Label = "Business Unit 3", Value = "BU3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 4, Key = DropdownKeys.BusinessUnit, Label = "Business Unit 4", Value = "BU4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 5, Key = DropdownKeys.BusinessUnit, Label = "Business Unit 5", Value = "BU5", ParentId = null, CreatedAt = seedTimestamp },

            // Division (6-10)
            new Dropdown { Id = 6, Key = DropdownKeys.Division, Label = "Division 1", Value = "Div1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 7, Key = DropdownKeys.Division, Label = "Division 2", Value = "Div2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 8, Key = DropdownKeys.Division, Label = "Division 3", Value = "Div3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 9, Key = DropdownKeys.Division, Label = "Division 4", Value = "Div4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 10, Key = DropdownKeys.Division, Label = "Division 5", Value = "Div5", ParentId = null, CreatedAt = seedTimestamp },

            // Market (11-15)
            new Dropdown { Id = 11, Key = DropdownKeys.Market, Label = "Market 1", Value = "Mkt1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 12, Key = DropdownKeys.Market, Label = "Market 2", Value = "Mkt2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 13, Key = DropdownKeys.Market, Label = "Market 3", Value = "Mkt3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 14, Key = DropdownKeys.Market, Label = "Market 4", Value = "Mkt4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 15, Key = DropdownKeys.Market, Label = "Market 5", Value = "Mkt5", ParentId = null, CreatedAt = seedTimestamp },

            // DepartmentName (16-20)
            new Dropdown { Id = 16, Key = DropdownKeys.DepartmentName, Label = "Department Name 1", Value = "DeptName1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 17, Key = DropdownKeys.DepartmentName, Label = "Department Name 2", Value = "DeptName2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 18, Key = DropdownKeys.DepartmentName, Label = "Department Name 3", Value = "DeptName3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 19, Key = DropdownKeys.DepartmentName, Label = "Department Name 4", Value = "DeptName4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 20, Key = DropdownKeys.DepartmentName, Label = "Department Name 5", Value = "DeptName5", ParentId = null, CreatedAt = seedTimestamp },

            // DepartmentRange (21-25)
            new Dropdown { Id = 21, Key = DropdownKeys.DepartmentRange, Label = "Department Range 1", Value = "DeptRange1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 22, Key = DropdownKeys.DepartmentRange, Label = "Department Range 2", Value = "DeptRange2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 23, Key = DropdownKeys.DepartmentRange, Label = "Department Range 3", Value = "DeptRange3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 24, Key = DropdownKeys.DepartmentRange, Label = "Department Range 4", Value = "DeptRange4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 25, Key = DropdownKeys.DepartmentRange, Label = "Department Range 5", Value = "DeptRange5", ParentId = null, CreatedAt = seedTimestamp },

            // AccountExternalReport (26-30)
            new Dropdown { Id = 26, Key = DropdownKeys.AccountExternalReport, Label = "Account External Report 1", Value = "AccExt1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 27, Key = DropdownKeys.AccountExternalReport, Label = "Account External Report 2", Value = "AccExt2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 28, Key = DropdownKeys.AccountExternalReport, Label = "Account External Report 3", Value = "AccExt3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 29, Key = DropdownKeys.AccountExternalReport, Label = "Account External Report 4", Value = "AccExt4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 30, Key = DropdownKeys.AccountExternalReport, Label = "Account External Report 5", Value = "AccExt5", ParentId = null, CreatedAt = seedTimestamp },

            // AccountGroup (31-35)
            new Dropdown { Id = 31, Key = DropdownKeys.AccountGroup, Label = "Account Group 1", Value = "AccGroup1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 32, Key = DropdownKeys.AccountGroup, Label = "Account Group 2", Value = "AccGroup2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 33, Key = DropdownKeys.AccountGroup, Label = "Account Group 3", Value = "AccGroup3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 34, Key = DropdownKeys.AccountGroup, Label = "Account Group 4", Value = "AccGroup4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 35, Key = DropdownKeys.AccountGroup, Label = "Account Group 5", Value = "AccGroup5", ParentId = null, CreatedAt = seedTimestamp },

            // AccountSubGroup (36-40)
            new Dropdown { Id = 36, Key = DropdownKeys.AccountSubGroup, Label = "Account SubGroup 1", Value = "AccSub1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 37, Key = DropdownKeys.AccountSubGroup, Label = "Account SubGroup 2", Value = "AccSub2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 38, Key = DropdownKeys.AccountSubGroup, Label = "Account SubGroup 3", Value = "AccSub3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 39, Key = DropdownKeys.AccountSubGroup, Label = "Account SubGroup 4", Value = "AccSub4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 40, Key = DropdownKeys.AccountSubGroup, Label = "Account SubGroup 5", Value = "AccSub5", ParentId = null, CreatedAt = seedTimestamp },

            // AccountName (41-45)
            new Dropdown { Id = 41, Key = DropdownKeys.AccountName, Label = "Account Name 1", Value = "AccName1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 42, Key = DropdownKeys.AccountName, Label = "Account Name 2", Value = "AccName2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 43, Key = DropdownKeys.AccountName, Label = "Account Name 3", Value = "AccName3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 44, Key = DropdownKeys.AccountName, Label = "Account Name 4", Value = "AccName4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 45, Key = DropdownKeys.AccountName, Label = "Account Name 5", Value = "AccName5", ParentId = null, CreatedAt = seedTimestamp },

            // AccountRange (46-50)
            new Dropdown { Id = 46, Key = DropdownKeys.AccountRange, Label = "Account Range 1", Value = "AccRange1", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 47, Key = DropdownKeys.AccountRange, Label = "Account Range 2", Value = "AccRange2", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 48, Key = DropdownKeys.AccountRange, Label = "Account Range 3", Value = "AccRange3", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 49, Key = DropdownKeys.AccountRange, Label = "Account Range 4", Value = "AccRange4", ParentId = null, CreatedAt = seedTimestamp },
            new Dropdown { Id = 50, Key = DropdownKeys.AccountRange, Label = "Account Range 5", Value = "AccRange5", ParentId = null, CreatedAt = seedTimestamp }
        );
    }
}

