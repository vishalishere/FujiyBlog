BEGIN TRAN
BEGIN TRY

CREATE TABLE [PostComments] (
    [Id] [int] NOT NULL IDENTITY,
    [AuthorName] [varchar](50),
    [AuthorEmail] [varchar](255),
    [AuthorWebsite] [varchar](200),
    [Comment] [varchar](max) NOT NULL,
    [IpAddress] [varchar](45) NOT NULL,
    [Avatar] [varchar](200),
    [CreationDate] [datetime] NOT NULL,
    [IsApproved] [bit] NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [Author_Id] [int],
    [ModeratedBy_Id] [int],
    [Post_Id] [int] NOT NULL,
    [ParentComment_Id] [int],
    CONSTRAINT [PK_PostComments] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Author_Id] ON [PostComments]([Author_Id])
CREATE INDEX [IX_ModeratedBy_Id] ON [PostComments]([ModeratedBy_Id])
CREATE INDEX [IX_Post_Id] ON [PostComments]([Post_Id])
CREATE INDEX [IX_ParentComment_Id] ON [PostComments]([ParentComment_Id])
CREATE TABLE [Posts] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [varchar](200) NOT NULL,
    [Description] [varchar](500),
    [Slug] [varchar](200) NOT NULL,
    [Content] [varchar](max),
    [ImageUrl] [varchar](255),
    [CreationDate] [datetime] NOT NULL,
    [LastModificationDate] [datetime] NOT NULL,
    [PublicationDate] [datetime] NOT NULL,
    [IsPublished] [bit] NOT NULL,
    [IsCommentEnabled] [bit] NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [Author_Id] [int] NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Author_Id] ON [Posts]([Author_Id])
CREATE TABLE [Users] (
    [Id] [int] NOT NULL IDENTITY,
    [Username] [varchar](20) NOT NULL,
    [Email] [varchar](255) NOT NULL,
    [Password] [varchar](50) NOT NULL,
    [DisplayName] [varchar](20),
    [FullName] [varchar](100),
    [Location] [varchar](20),
    [CreationDate] [datetime] NOT NULL,
    [LastLoginDate] [datetime],
    [About] [varchar](500),
    [BirthDate] [datetime],
    [Enabled] [bit] NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
)
CREATE TABLE [RoleGroups] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [varchar](50) NOT NULL,
    [AssignedRoles] [varchar](max),
    CONSTRAINT [PK_RoleGroups] PRIMARY KEY ([Id])
)
CREATE TABLE [Tags] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [varchar](50) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
)
CREATE TABLE [Categories] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [varchar](50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
)
CREATE TABLE [Settings] (
    [Id] [int] NOT NULL,
    [Description] [varchar](500) NOT NULL,
    [Value] [varchar](max),
    CONSTRAINT [PK_Settings] PRIMARY KEY ([Id])
)
CREATE TABLE [WidgetSettings] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [varchar](50) NOT NULL,
    [WidgetZone] [varchar](50) NOT NULL,
    [Position] [int] NOT NULL,
    [Settings] [varchar](max),
    CONSTRAINT [PK_WidgetSettings] PRIMARY KEY ([Id])
)
CREATE TABLE [Pages] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [varchar](200) NOT NULL,
    [Description] [varchar](500),
    [Slug] [varchar](200) NOT NULL,
    [Content] [varchar](max),
    [Keywords] [varchar](500),
    [CreationDate] [datetime] NOT NULL,
    [LastModificationDate] [datetime] NOT NULL,
    [PublicationDate] [datetime] NOT NULL,
    [IsPublished] [bit] NOT NULL,
    [IsFrontPage] [bit] NOT NULL,
    [ParentId] [int],
    [ShowInList] [bit] NOT NULL,
    [IsDeleted] [bit] NOT NULL,
    [Author_Id] [int] NOT NULL,
    CONSTRAINT [PK_Pages] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ParentId] ON [Pages]([ParentId])
CREATE INDEX [IX_Author_Id] ON [Pages]([Author_Id])
CREATE TABLE [RoleGroupUsers] (
    [RoleGroup_Id] [int] NOT NULL,
    [User_Id] [int] NOT NULL,
    CONSTRAINT [PK_RoleGroupUsers] PRIMARY KEY ([RoleGroup_Id], [User_Id])
)
CREATE INDEX [IX_RoleGroup_Id] ON [RoleGroupUsers]([RoleGroup_Id])
CREATE INDEX [IX_User_Id] ON [RoleGroupUsers]([User_Id])
CREATE TABLE [TagPosts] (
    [Tag_Id] [int] NOT NULL,
    [Post_Id] [int] NOT NULL,
    CONSTRAINT [PK_TagPosts] PRIMARY KEY ([Tag_Id], [Post_Id])
)
CREATE INDEX [IX_Tag_Id] ON [TagPosts]([Tag_Id])
CREATE INDEX [IX_Post_Id] ON [TagPosts]([Post_Id])
CREATE TABLE [CategoryPosts] (
    [Category_Id] [int] NOT NULL,
    [Post_Id] [int] NOT NULL,
    CONSTRAINT [PK_CategoryPosts] PRIMARY KEY ([Category_Id], [Post_Id])
)
CREATE INDEX [IX_Category_Id] ON [CategoryPosts]([Category_Id])
CREATE INDEX [IX_Post_Id] ON [CategoryPosts]([Post_Id])
ALTER TABLE [PostComments] ADD CONSTRAINT [FK_PostComments_Users_Author_Id] FOREIGN KEY ([Author_Id]) REFERENCES [Users] ([Id])
ALTER TABLE [PostComments] ADD CONSTRAINT [FK_PostComments_Users_ModeratedBy_Id] FOREIGN KEY ([ModeratedBy_Id]) REFERENCES [Users] ([Id])
ALTER TABLE [PostComments] ADD CONSTRAINT [FK_PostComments_Posts_Post_Id] FOREIGN KEY ([Post_Id]) REFERENCES [Posts] ([Id])
ALTER TABLE [PostComments] ADD CONSTRAINT [FK_PostComments_PostComments_ParentComment_Id] FOREIGN KEY ([ParentComment_Id]) REFERENCES [PostComments] ([Id])
ALTER TABLE [Posts] ADD CONSTRAINT [FK_Posts_Users_Author_Id] FOREIGN KEY ([Author_Id]) REFERENCES [Users] ([Id])
ALTER TABLE [Pages] ADD CONSTRAINT [FK_Pages_Pages_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [Pages] ([Id])
ALTER TABLE [Pages] ADD CONSTRAINT [FK_Pages_Users_Author_Id] FOREIGN KEY ([Author_Id]) REFERENCES [Users] ([Id])
ALTER TABLE [RoleGroupUsers] ADD CONSTRAINT [FK_RoleGroupUsers_RoleGroups_RoleGroup_Id] FOREIGN KEY ([RoleGroup_Id]) REFERENCES [RoleGroups] ([Id]) ON DELETE CASCADE
ALTER TABLE [RoleGroupUsers] ADD CONSTRAINT [FK_RoleGroupUsers_Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
ALTER TABLE [TagPosts] ADD CONSTRAINT [FK_TagPosts_Tags_Tag_Id] FOREIGN KEY ([Tag_Id]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
ALTER TABLE [TagPosts] ADD CONSTRAINT [FK_TagPosts_Posts_Post_Id] FOREIGN KEY ([Post_Id]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE
ALTER TABLE [CategoryPosts] ADD CONSTRAINT [FK_CategoryPosts_Categories_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
ALTER TABLE [CategoryPosts] ADD CONSTRAINT [FK_CategoryPosts_Posts_Post_Id] FOREIGN KEY ([Post_Id]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE
CREATE TABLE [__MigrationHistory] (
    [MigrationId] [nvarchar](255) NOT NULL,
    [CreatedOn] [datetime] NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK___MigrationHistory] PRIMARY KEY ([MigrationId])
)
BEGIN TRY
    EXEC sp_MS_marksystemobject '__MigrationHistory'
END TRY
BEGIN CATCH
END CATCH
INSERT INTO [__MigrationHistory] ([MigrationId], [CreatedOn], [Model], [ProductVersion]) VALUES ('201203160118417_v03', '2012-03-16T01:26:01.488Z', 0x1F8B0800000000000400ED1DCB6E23B9F11E20FF20E8940458CB9EEC2C6607F62E3C9EF1C2C8BC30F2EC02B90CDA6A5AEE6CAB5BE9A63CF6B7E5904FCA2F84FD62F3517C365B92677593C866B1AA582CB28A45D6FFFEF3DFD39F1F56E9E41E1565926767D393A3E3E904658B3C4EB2E5D974836FBF7B31FDF9A73FFFE9F44DBC7A98FCDA7DF7ACFA8EB4CCCAB3E91DC6EB97B359B9B843ABA83C5A258B222FF35B7CB4C857B328CE67CF8E8F5FCC4E8E67888098125893C9E9A74D869315AAFF90BF1779B6406BBC89D277798CD2B22D2735F31AEAE47DB442E53A5AA0B3E9E5E65FC9E3AB345F1E5DE4053A7A4300E1C7CB827CF0352F7E9F4ECED3242258CD517AEB88E2F18F158A53DA39E9BE817EFDB846350A67D38F79892FF2D50A6598FD907CFA0FF4C81590A28F45BE46057EFC846EDBE657F17432E3DBCDC486B419D3A6C280FCCAF0DF9F4D27EF37691ADDA4A4E0364A4B349DAC7F7839C78419BFA00C151146F1C708635464555B5453D072E2E5FA073B66FC383B7E5631631665598E234C065D425C40F37C83EFF2A2FADDA13BC70591A2E9E4327940F15B942DF11D45F95DF4D0953C27A2F4394B88CCF514F524E26283ECBA7EB38A92D4B1EF67CF9F87E9FC37745326D89574C2E9A1DD77C2E8D631F9A9EBB82DD0F77CB53E8FE30295A563DFDF6B596ED5F5F97D84A36207CC2E503D175E47FD5057BFAF939507FFCAF3F5BAC8EF119DDFAFF23C4551E601E9354A11F600F43EBA4F96354902C84ACF4D279F505A579677C9BA51A9478C02FCD27C7459E4AB4F79CA2BC7BAEECB3CDF148B8A53B9E283EBA85822EC80565490B654E64DF8F15F2B10653FD263CC7DE98AFA7B5492116A5B9763E0DE6164C6BDA3D216F746C781387F2E51F1A5A927EB4EDF63C9E2ACFC48C259FDA52BCED54EA25E0C5F3DAA11A71F693107BF8251873F85703F9DF59B0BE396E3B0D7E0D0BC4E701A78ADB552B4AF51B928927583A2E32667F0E2334F37CB1DD04CF6E638F806C386DEAB55B4449F8B1D6CE9822EF36FA31213AD90DC268B70403F6E6ED290F0AECA1A6279176233D2AABD3759D56A1F37379AE5ACDE9574F5FCA2DB16835B84AECE755360BF1D306DB5B48B3FBB17B345ED3A5AC268918A1A22B74ED2420991BEC615830B22CDCBBC48108C475BFD2823C3D7481809D58316E76AD13F2CCE1C9A154B327737C0B3E14BD5081E003B6D1C95E5D7BC889DF704C3372449B94EA3470FAF8B9EDD36ABE425F9DAA3E393E13BA1B7F922F2D8830D2739F8C6E06DBE4C8CD0ACBC5037F9C6758F16604FFA2A29F05D08FC7D370B5A07867A59352CF1D0622A2EFF6E9B0DD1C20C6F498BDB12B3CDED6C49DB9130C4A60689D09BDFB65454007F29F2CD1A469D567FA9FAE4F015AA24E910EB076D2828B0C3AE82779F853E58B073349765B2CC505C8D8AAB9FDBC704564A6F2B94C304579C5D2AC1F6125CB2CF3F88EC2E44D66309349870A29CC8C69D97847476D7414C9E8898585BD8A2C0280C702FA999238C2B9E3C01A1799F67680B02339A17DA6A49FC354A37AEF2EABC145A4BC76F494C44EB09C9C8B7A758845E9B11F9673D15B6DD375137093B2D54C363386869A469F4FD9EFD0960B44407D93E9C00FED14E0089AC566E55D7891880D387134017279C048A6C14335C6BAD81A09AB0158D4EB29A3677F9D7ABEC6D52E2E194850FB4AA29841D9584815FBA7AC651D917CB67914C9DAB834C772A5A81055CA67D318C89E65454B5F89D9765BE486A0418D707EC17E5097B93C5136B2769A34F3A9F25511F9B14276B32A3084A67D3E3A3A313897136F0A96BB087CF460C0BDDFC4D640943BC054F6047AB166983D77538570CA15223B345F485A950553AC67AFC7A3FAC1E3B2D5C806E88B1FE04B367192AA4C0D8057E205C6804CF49F4F49D78D3D73BAA54E8005EAB1E99CA27E9401A10C4E0C42707C204D78A0A23959FA5478B3AD51CE854C5478C45AC14C8A2932D3880D84771E8415B52ED2FBBEA685E2B1CE1B0E4B07C80C387ADFA90170317D6303B1B25A2D0368741ADDE5D3AD00DEC8C0CE0C0F58E58D7A802924429B18B4A5C44498665533CC916C93A4AD59D0B4D2CEDF78ACB14B858F31AAD515699E06A0EDAF4DAEFB9E5BE69178257C1C41557D9302D69D0C673A06C8CB3A4359BDCCA82261C41050D9D69EFB011732DBA894AD1BBD3B49A232CAB12620CF71B67689A4A54CAA054308C8DDB1346A971C3214363F6005E82C06CB70C609AB8440940BDD41B9AB2018512807E213540E9DD83128CCE0F6D02C179AD2140BC5BDB38A6447EC131ADE781D09811547E6015B127CCF7C64015515FB8986494282A6692FA71B1C018703C3DA24394E7872DAF14412E0A6659586AAEB69A3BBBF4A6D978FC920214642669ED362BCB8D419FD5331A9EA86C3513633D38C0459CC9D42B8D38A319270C9A9E60C8701B815826B640265561CF192C3A06CB46FB6BA8946D3813933C68140FC6654275F69D8D85C720CDAE5A1AC21546DD08D4CBF7126099569B7C76469FA54AB233F3C6E6037F5DD3C010B535E8680F0E661168018EB716702E6D80492ABBD06819B22837BB211D07005BD004C097588DDA57193A4653C79DD8706ABFF3DB539386D69DCE9AC73ADA82D399E2558FD377D17A5DED7BFB966DC964DE3CF171F1DDDCFDE98E550363B6E0B4AD6880D19E705E10C608B5D559678C2E93A2C4D4329B5CC42BE9336B03AEEB0FB0E3E421EBB6EF5DA3EAB76030828F9E7006A06CE2B7E0C8E7CBEA8B9A7604CF71B9F5A47A83254AA3028813B8C8D3CD2A53FB2AD4ADD9C74258286CB92BB4F6F68F0CAEAD7085479FF49021D22A7B98746960A1298C762DDFFB573738F6F7C50E74B6CF687004B6650E947167E51C795C8D038DCCCB181C914CB90B347A68CB03A3C532ACD3993069244F98345B05052A6A006BFD105C31786A846DA98236928705D016D9C3E0A27258485C853DBC26D08605D494B84CF73666869FEE6DA183F0D24BF01C8769E92EA7291CD7C24286BFB0EF410A7261814B952E2A810976E1950253E1024FBCF3CE03156BBF49E5A572DD782B2FF96E750DD1A4BCE066E328AFFEAE330BA32FB58704EC5E9CF72DFD3D646E9ED0520785CADE2BE6142A5B610FAFBF2BCC02EB4B1D940EBDFBCB291A5ABA6B85C8DCE815352153E5B0476B2EF6725BB4A6C81E06734B9785C3143BC829A4E1348A6D47CA88710207D4488ACB993558935AD2B41D4737C9F3CDD9AEE26F3F7232C857EDCDB8D7FEE180232EDD6AB41A6BB0D5AE47794723C2B8AF038E0B7C97D06A70D44DFFA02344CFA1038E0F7823CB6A78942DC7199DD0A6637B3D8E85D416EDCD780BD10701475D731BCF6AEC0DED773D3F5510D82B6F2C1CB6DC61174F2FB171BB785AEAE0C6A001269C2B8396EE8D4436A71821FD5ED28DB91AA2D1EF05363BF8BDB6EFF7EAAF7EB180FAD25D9B7907BF57D38CB9E9C5C3632A5C1C185DE829EFC05005A46A2499B9F3C5C93353FEB4BD70FC09ADEC8A5384F33979DF14301C0E10AB8368C067A60D05945969A57EDB336E38709941630886CAE06DEF05428B1A519C71BDEA4FAECAEA8621BD5D6845B7788AEF27468A484737395200092048DA2849CF71629E0E0F264EDAE8CBBD92273DF583854A0A0775F7BE752D952E36E8080018184530A9E768F4D002C88C223AD513B55A02DDB01A3CCE5CD0ABD381356D65732C0DF00E0874DDF9920244EF6E65D20F1E46269CD7C569DAB5013CA396A32885017BF2AB82136000A5B8624F746A41D8F2188AE1CACE5E56D56876F596430AC73A7B3292020B30B870ECF4131A613924DB2776B06D3A6C57A68AC0DE1E37EDD07A525A58136AEE37D03C8C80230E0594FB0E3D072BB40C40F1F47BB50F37913F5CA8D8F87427D7AA7A87063850A1819063D277BF439303EDF744374821F7E227D4D5D496D0FF34E4BE0D773767D794E2DF9B4FA61382FB7D1257B1EFF3C712A3D551F5C1D1FCDFE9459AD43AA4FBE05D9425B7A8C4D7F9EF28AB1F207BE19F9493BE0C579671BAC7993913AA4575AFE2B93E3E2D65D4BC8F8AC55D159D2D3C9B38385D2604B8CE8C1120172608FBD8196B21D1650BF52FABE8E1AFC3535742387EFFDC7DC4B8BC94A10807DEA28BC96F1C26E9E44D8287BF83E6038451DDCC2472E38DE8ABF20644B799200487B7EAD8F5DA129B3DCF04388A6EE3DEEFB49828BE8F73C21AD3790EB22F6F86C256785653A5D07C52E50552E741358FEE154C6FA08A573007A847E9154C3FFD08E7C0DB5B5D0B00D9F31468A368253175193CD587E525B3989B5E49C7CC7B43DF8C62662EF8A40B83A09EB86B663117581864836B3E29D11704CD39D157A0D54DCAE2E58B9CB3BA7B0A699146D1346E569D7FAE22FB5DC57E27FAD9CF417802A96F9E38E37696D9C3C702F4B33FDCB3AE8C30A9779C47653FA554062927370904F8A390B9C447FCC4BC252388C96E32911C3C107BEF8110537504A2FAE081F034F8811C1C3E60C4FC1B1E9E5539FBC637E905D1C41EDAA94843F8A0DC4011D46756AC7C4FFEEB0D45203833C128313B362AC3BDE44F15A1256606767D0C382B703D6E70B6347CF9A70FAB0AC844AEA33DE064A8C43343D3A8708F7933A09CDEFBF77AA55EF1DE8ACD6E6EE2F42EBDF6B53AB93B6D8CC7165EA4F74CB6731084D08260BE97B18DFC042EC94C5CD38BEC8900289E8DDBB900688241B73DF2AE095DFCF3AAA82036C1545B970B97F10A271E35B15622621134BA2559316531B15A244CC2E091CB6BEFD78427B12BB0CD61E497668887214F75AB0C37DEB98AB6959DC87156EF754EA2E1B3D946589EDA6CB615A65DCF669BABA050F210BB9C9127524CFC87ACF1674DCE17CD93F01751B98862D9DCADE2C68D5848B227D48C2243BAC7F0820B92F66AAF8F3F6D1742055D7570D720DFA0286D4B1DB94B91E6E6F41604487F0796CF7A634A7C3A92E074AE5AA1F71177A2F0938CC16545715319EC4A7DC778AB4262D02F960E896F444CB6E5C3709193DDFA2F2CAE5F03F9A4ACB20D8F2435DC610684C788F2A3796134B80CE9EED183FD192EBF6F5F98F658F5EC5288B6A5849C05689B9A48B8BD4A834FC44C4BE200B6B78A65EFAB29056E7367F56C1ADFE464C09B93406D2233A82F658E5C157433D866072D816D8A21B070722E112C63764AB0993AA80375AE4C28EFAE2AED2E04194AD4A84AC8FBA84DC70B4157E74454A5EBD565EB857A50BD92AACFE56B4EE50BF525A603364967ED1792A5B32E06A5134C68A7142385980AF55A71B2135CBA0184C44A3DD9DA4A7BF15274C2576BC4EC11EE6E779994A50C7E801E579C42310DB9727141DDD7B4C8FB48BAFC84CEE084A812B6FB46E6C8F94E6DC950B56F4E4C4665C5E08CCE7EE26C948C5DA665957293EAC9A1475B8656BB4ABEEA3142364C189E449DA68235E65257BC65039F65307833A51A72C13D03F01667780674A96CCD0C801F181A34CADB235B4E86AE49AA6E1E6B66134F13D5E808157668DC138E2189538FA6E9DDC541EBE6B8E42952BB9B92C59B4751349BF8B4363A82A11DB1FC926370D2D5C36BF5F2E2A0310E4DB243026CF9D5ADD3D9A74D56DD0B69FEBD46F595DD0E44F52E5C86169CFF847E7395DDE69D1F47C0A8FB447C1C07E1288E70745EE0E4365A6052BD4065599BA1F57DC2EA65821B145F651F3678BDC18464B4BA493909AADC41BAFEEB2CDF3CCEA71FEAFB4F650812089A497595E643F66A93A431C5FB1288EB5680A8FC4CEDB5B16A2C7165702C1F29A4F752761615A0967DD43D768D56EB94002B3F64F3E81EA97133F390E7D8E9EB245A16D18AE56053D2B93422D233D305E9806DD1F747FE12718D570F3FFD1FBFDB8425EBC10000, '4.3.1')


insert [dbo].[RoleGroups]
       ([Name],
        [AssignedRoles])
values ('Admin' ,
        'AccessAdminPages,AccessAdminSettingsPages,ManageWidgets,ViewPublicComments,ViewUnmoderatedComments,CreateComments,ModerateComments,ViewPublicPosts,ViewUnpublishedPosts,CreateNewPosts,EditOwnPosts,EditOtherUsersPosts,DeleteOwnPosts,DeleteOtherUsersPosts,PublishOwnPosts,PublishOtherUsersPosts,ViewPublicPages,ViewUnpublishedPages,CreateNewPages,EditOwnPages,EditOtherUsersPages,DeleteOwnPages,DeleteOtherUsersPages,PublishOwnPages,PublishOtherUsersPages,ViewRoleGroups,CreateRoleGroups,EditRoleGroups,DeleteRoleGroups,EditOwnRoleGroups,EditOtherUsersRoleGroups,CreateNewUsers,EditOwnUser,EditOtherUsers')



insert [dbo].[RoleGroups]
       ([Name],
        [AssignedRoles])
values ('Editor' ,
        'AccessAdminPages,ViewPublicPosts,ViewUnpublishedPosts,CreateNewPosts,EditOwnPosts,DeleteOwnPosts,PublishOwnPosts,EditOwnUser,ViewPublicComments,ViewUnmoderatedComments,CreateComments,ModerateComments,ViewPublicPages,ViewUnpublishedPages,CreateNewPages,EditOwnPages,DeleteOwnPages,PublishOwnPages' )



insert [dbo].[RoleGroups]
       ([Name],
        [AssignedRoles])
values ('Anonymous' ,
        'ViewPublicPosts,ViewPublicComments,CreateComments,ViewPublicPages' )

insert [dbo].[Users]
       ([Username],
        [Email],
        [Password],
        [DisplayName],
        [FullName],
        [Location],
        [CreationDate],
        [LastLoginDate],
        [About],
        [BirthDate],
        [Enabled])
values ('admin' ,
        'admin@example.com' ,
        'admin' ,
        null,
        null,
        null,
        GETUTCDATE(),
        null,
        null,
        null,
        1 )



insert [dbo].[Posts]
       ([Title],
        [Description],
        [Slug],
        [Content],
        [CreationDate],
        [LastModificationDate],
        [PublicationDate],
        [IsPublished],
        [IsCommentEnabled],
        [IsDeleted],
        [Author_Id])
values ('Example post. You blog is now installed' ,
        null,
        'example' ,
        'Example post' ,
        GETUTCDATE(),
        GETUTCDATE(),
        GETUTCDATE(),
        1 ,
        1 ,
        0 ,
        1 )



insert [dbo].[RoleGroupUsers]
       ([RoleGroup_Id],
        [User_Id])
values (1 ,
        1 )

COMMIT

END TRY
BEGIN CATCH
    ROLLBACK
END CATCH
