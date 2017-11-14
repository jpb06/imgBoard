namespace ImgBoard.Dal.Migrations.Tests
{
    using ImgBoard.Models.Main;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class TestsConfiguration : DbMigrationsConfiguration<ImgBoard.Dal.Context.EndObjects.ImgBoardTestContext>
    {
        public TestsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Tests";
        }

        protected override void Seed(ImgBoard.Dal.Context.EndObjects.ImgBoardTestContext context)
        {
            #region Categories
            var category1 = new Category
            {
                Id = 1,
                Title = "Nature"
            };
            var category2 = new Category
            {
                Id = 2,
                Title = "Technology"
            };
            var category3 = new Category
            {
                Id = 3,
                Title = "Space"
            };
            #endregion

            #region Users
            var user1 = new User
            {
                Id = 1,
                Login = "a",
                Password = "a",
                UserName = "User A"
            };
            var user2 = new User
            {
                Id = 2,
                Login = "b",
                Password = "b",
                UserName = "User B"
            };
            #endregion

            #region Images
            // no cat
            var image1 = new Image
            {
                Id = 1,
                IdCategory = null,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("1be96b96ce194f1ab2bc54db0c269df9")
            };
            var image2 = new Image
            {
                Id = 2,
                IdCategory = null,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("0c85e4d2fa1443fbaabaa069aa7879f3")
            };
            var image3 = new Image
            {
                Id = 3,
                IdCategory = null,
                IdUploader = 1,
                Name = "Some name",
                Description = null,
                FileId = new Guid("e7f2cd1471bc4a3ab64ad5dfa4774b64")
            };
            var image4 = new Image
            {
                Id = 4,
                IdCategory = null,
                IdUploader = 2,
                Name = "Some cool name",
                Description = null,
                FileId = new Guid("e2eb8ffbfc9542c3911ab53c8dbd1da9")
            };
            var image5 = new Image
            {
                Id = 5,
                IdCategory = null,
                IdUploader = 2,
                Name = null,
                Description = "Some description",
                FileId = new Guid("5d02a31ac3b74a219c72750bcbe683bd")
            };
            // cat 1
            var image6 = new Image
            {
                Id = 6,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Something",
                Description = "Something cool",
                FileId = new Guid("0974ed5725964ad0b71c65314c79bff3")
            };
            var image7 = new Image
            {
                Id = 7,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Blabla",
                Description = null,
                FileId = new Guid("7fdb4ad242124b07b7c16b772066606f")
            };
            var image8 = new Image
            {
                Id = 8,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Nono",
                Description = "Yolo",
                FileId = new Guid("1697cdbe47134c64a802446724594b5b")
            };
            var image9 = new Image
            {
                Id = 9,
                IdCategory = 1,
                IdUploader = 1,
                Name = null,
                Description = "Super cool",
                FileId = new Guid("d8e7e1ad6810461ca5e888215eee456a")
            };
            var image10 = new Image
            {
                Id = 10,
                IdCategory = 1,
                IdUploader = 1,
                Name = "Ahaha",
                Description = null,
                FileId = new Guid("2749a186cda74da9a090fad2db1aa1ed")
            };

            var image11 = new Image
            {
                Id = 11,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Not cool",
                Description = "Yes",
                FileId = new Guid("0bd69a48caa4407899283251a2c7aa62")
            };
            var image12 = new Image
            {
                Id = 12,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Meh",
                Description = null,
                FileId = new Guid("d68a9e301fc64f5c93a095d624617be7")
            };
            var image13 = new Image
            {
                Id = 13,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Gah",
                Description = null,
                FileId = new Guid("45c6107002384fad81649c027ddde337")
            };
            var image14 = new Image
            {
                Id = 14,
                IdCategory = 1,
                IdUploader = 2,
                Name = "Ahaha",
                Description = "Super",
                FileId = new Guid("fefcfdf503b04350a5c0ccd6e41c0088")
            };
            var image15 = new Image
            {
                Id = 15,
                IdCategory = 1,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("3e6c20cc95c34c8cabb436453a3fa476")
            };
            var image16 = new Image
            {
                Id = 16,
                IdCategory = 1,
                IdUploader = 2,
                Name = null,
                Description = "Ouah",
                FileId = new Guid("8855611b7bff43c1a8c5e3d42c2ae0c7")
            };
            var image17 = new Image
            {
                Id = 17,
                IdCategory = 1,
                IdUploader = 2,
                Name = "That's a title",
                Description = "That's great",
                FileId = new Guid("db7dc17917344372b27ec4508fb1ea85")
            };
            // cat 2
            var image18 = new Image
            {
                Id = 18,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Lalala",
                Description = "That's a rather long description",
                FileId = new Guid("14f22be857ab433bb20e2a91538e9931")
            };
            var image19 = new Image
            {
                Id = 19,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Not good",
                Description = "Nope nope nope",
                FileId = new Guid("02f4340c01e14e90844a165ab8027fe1")
            };
            var image20 = new Image
            {
                Id = 20,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Something",
                Description = "That's a rather long description, like really long",
                FileId = new Guid("2dd1b1661f1d45ceb4aa648dd2e135cb")
            };
            var image21 = new Image
            {
                Id = 21,
                IdCategory = 2,
                IdUploader = 1,
                Name = "That's the id 21",
                Description = null,
                FileId = new Guid("f316398a86d84f139b7146565e50e0e6")
            };
            var image22 = new Image
            {
                Id = 22,
                IdCategory = 2,
                IdUploader = 1,
                Name = "That's the id 22",
                Description = null,
                FileId = new Guid("ed7fd773ef0f4ecca0c67bebe23359da")
            };
            var image23 = new Image
            {
                Id = 23,
                IdCategory = 2,
                IdUploader = 1,
                Name = null,
                Description = null,
                FileId = new Guid("6e11274767b14b6895174d44e7b2b0fe")
            };
            var image24 = new Image
            {
                Id = 24,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Test",
                Description = null,
                FileId = new Guid("e765abae7db941b5bbf605be6102ecaa")
            };

            var image25 = new Image
            {
                Id = 25,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 25",
                Description = "Description",
                FileId = new Guid("6663128d864045c3ab6b70d8b6d80270")
            };
            var image26 = new Image
            {
                Id = 26,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 26",
                Description = "nghhh",
                FileId = new Guid("5c68ca911ace45049997365938e1bafa")
            };
            var image27 = new Image
            {
                Id = 27,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 27",
                Description = "That's a rather long description like really super horribly long like is this really necessary stop it now",
                FileId = new Guid("9b3702bb5598472dab5408d49c0c2987")
            };
            var image28 = new Image
            {
                Id = 28,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 28",
                Description = "Bored",
                FileId = new Guid("5f153307e70c477491445a9946b118db")
            };
            var image29 = new Image
            {
                Id = 29,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 29",
                Description = "Yololo",
                FileId = new Guid("ed0303c101ca46dba617cad442d60331")
            };
            var image30 = new Image
            {
                Id = 30,
                IdCategory = 2,
                IdUploader = 2,
                Name = "a",
                Description = "desc",
                FileId = new Guid("5466bcea687c41bbb70ecfb4309a61f3")
            };
            var image31 = new Image
            {
                Id = 31,
                IdCategory = 2,
                IdUploader = 2,
                Name = "blah",
                Description = "not",
                FileId = new Guid("ba05b9d7ee1145dca93834cedd85c7a1")
            };
            var image32 = new Image
            {
                Id = 32,
                IdCategory = 2,
                IdUploader = 2,
                Name = "That's image 32",
                Description = null,
                FileId = new Guid("34855651602d4fa7889326a22212ff70")
            };
            var image33 = new Image
            {
                Id = 33,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = "Description for image 33",
                FileId = new Guid("b0b37c95a8334ee68946b10f8738e767")
            };
            var image34 = new Image
            {
                Id = 34,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = "Description for image 34",
                FileId = new Guid("35696e783af746ec9a4ed862ebc59620")
            };
            var image35 = new Image
            {
                Id = 35,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Something something something",
                Description = "what?",
                FileId = new Guid("0d8de8d2c57e47a4959841f409cca22f")
            };
            var image36 = new Image
            {
                Id = 36,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("98f7e09d0363492397a1c16e88015909")
            };
            var image37 = new Image
            {
                Id = 37,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("743ec8da043349db9c6a768a2db5fec4")
            };
            var image38 = new Image
            {
                Id = 38,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Lili",
                Description = "originality",
                FileId = new Guid("3ebcb683bd0542f9b5959ea0972a409f")
            };
            var image39 = new Image
            {
                Id = 39,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Stop",
                Description = "That's a description",
                FileId = new Guid("0918d9738bff40008a64fdbff5bb3eee")
            };
            var image40 = new Image
            {
                Id = 40,
                IdCategory = 2,
                IdUploader = 1,
                Name = "Huge",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus dapibus bibendum. Nunc dapibus odio turpis, in maximus nisl hendrerit id. Integer malesuada pharetra nibh, eget cursus sapien molestie nec. Nulla blandit tortor augue, et consectetur lectus egestas sed. Pellentesque blandit consequat euismod. In at feugiat nulla, vel tempor urna. Proin varius, turpis non viverra venenatis",
                FileId = new Guid("659eb8e26fe140cebd30a52e1378efbe")
            };
            var image41 = new Image
            {
                Id = 41,
                IdCategory = 2,
                IdUploader = 2,
                Name = null,
                Description = null,
                FileId = new Guid("69f718225c9a4a50a241d1011a1d847a")
            };
            var image42 = new Image
            {
                Id = 42,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere non magna a luctus. Suspendisse gravida ipsum eu metus",
                FileId = new Guid("45ed3c53370b446d83076699d5fdef58")
            };
            var image43 = new Image
            {
                Id = 43,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Ffffffff",
                Description = "boring",
                FileId = new Guid("1db7b3b8b2604d09956a7101f7a621f7")
            };
            var image44 = new Image
            {
                Id = 44,
                IdCategory = 2,
                IdUploader = 2,
                Name = "Finally",
                Description = "Annoying",
                FileId = new Guid("5f56e5c7ac66467ea475cd7de17077fb")
            };
            var image45 = new Image
            {
                Id = 45,
                IdCategory = 2,
                IdUploader = 2,
                Name = "agagaga",
                Description = "grrrr",
                FileId = new Guid("61b8ad267bec46ada3fb2e7fcf8a7de5")
            };
            #endregion

            #region Tags
            var tag1 = new Tag
            {
                Id = 1,
                Name = "Cool",
                Images = new List<Image>()
            };
            var tag2 = new Tag
            {
                Id = 2,
                Name = "Meh",
                Images = new List<Image>()
            };
            var tag3 = new Tag
            {
                Id = 3,
                Name = "Bad",
                Images = new List<Image>()
            };
            #endregion

            tag1.Images.Add(image1);
            tag1.Images.Add(image2);
            tag1.Images.Add(image3);
            tag1.Images.Add(image4);
            tag1.Images.Add(image5);
            tag1.Images.Add(image6);
            tag1.Images.Add(image7);
            tag1.Images.Add(image8);
            tag1.Images.Add(image9);
            tag1.Images.Add(image10);
            tag1.Images.Add(image11);
            tag1.Images.Add(image12);
            tag1.Images.Add(image13);
            tag1.Images.Add(image14);
            tag1.Images.Add(image15);
            tag1.Images.Add(image16);

            tag2.Images.Add(image19);
            tag2.Images.Add(image20);
            tag2.Images.Add(image21);
            tag2.Images.Add(image22);
            tag2.Images.Add(image23);
            tag2.Images.Add(image24);
            tag2.Images.Add(image25);
            tag2.Images.Add(image26);
            tag2.Images.Add(image27);
            tag2.Images.Add(image2);

            tag3.Images.Add(image19);
            tag3.Images.Add(image20);
            tag3.Images.Add(image21);
            tag3.Images.Add(image22);
            tag3.Images.Add(image23);
            tag3.Images.Add(image24);
            tag3.Images.Add(image25);
            tag3.Images.Add(image26);
            tag3.Images.Add(image27);
            tag3.Images.Add(image28);
            tag3.Images.Add(image29);
            tag3.Images.Add(image30);
            tag3.Images.Add(image31);
            tag3.Images.Add(image32);
            tag3.Images.Add(image33);
            tag3.Images.Add(image34);
            tag3.Images.Add(image35);
            tag3.Images.Add(image36);
            tag3.Images.Add(image37);
            tag3.Images.Add(image38);
            tag3.Images.Add(image39);
            tag3.Images.Add(image40);
            tag3.Images.Add(image41);
            tag3.Images.Add(image42);
            tag3.Images.Add(image43);
            tag3.Images.Add(image44);
            tag3.Images.Add(image1);
            tag3.Images.Add(image3);

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.Images.Add(image1);
            context.Images.Add(image2);
            context.Images.Add(image3);
            context.Images.Add(image4);
            context.Images.Add(image5);
            context.Images.Add(image6);
            context.Images.Add(image7);
            context.Images.Add(image8);
            context.Images.Add(image9);
            context.Images.Add(image10);
            context.Images.Add(image11);
            context.Images.Add(image12);
            context.Images.Add(image13);
            context.Images.Add(image14);
            context.Images.Add(image15);
            context.Images.Add(image16);
            context.Images.Add(image17);
            context.Images.Add(image18);
            context.Images.Add(image19);
            context.Images.Add(image20);
            context.Images.Add(image21);
            context.Images.Add(image22);
            context.Images.Add(image23);
            context.Images.Add(image24);
            context.Images.Add(image25);
            context.Images.Add(image26);
            context.Images.Add(image27);
            context.Images.Add(image28);
            context.Images.Add(image29);
            context.Images.Add(image30);
            context.Images.Add(image31);
            context.Images.Add(image32);
            context.Images.Add(image33);
            context.Images.Add(image34);
            context.Images.Add(image35);
            context.Images.Add(image36);
            context.Images.Add(image37);
            context.Images.Add(image38);
            context.Images.Add(image39);
            context.Images.Add(image40);
            context.Images.Add(image41);
            context.Images.Add(image42);
            context.Images.Add(image43);
            context.Images.Add(image44);
            context.Images.Add(image45);

            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            context.Tags.Add(tag3);
        }
    }
}
