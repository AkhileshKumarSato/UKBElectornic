USE [SATO_UKB_ELECTRONICS]
GO
/****** Object:  UserDefinedTableType [dbo].[UserDefineTBL_JobDetail]    Script Date: 09-03-2023 10:39:40 ******/
CREATE TYPE [dbo].[UserDefineTBL_JobDetail] AS TABLE(
	[ProductCode] [nvarchar](50) NULL,
	[LotNo] [nvarchar](50) NULL,
	[ManufacturedDate] [nvarchar](50) NULL,
	[SerialNo] [nvarchar](50) NULL,
	[PassStatus] [nvarchar](50) NULL,
	[Line] [nvarchar](20) NULL,
	[FilePath] [nvarchar](500) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetShiftTime]    Script Date: 09-03-2023 10:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetShiftTime]
(
	@TimeToCheck TIME(7)
)
RETURNS 
VARCHAR AS 
	BEGIN      
		DECLARE @RetCode varchar(50)
		
		select @RetCode=[ShiftName] from TBL_ShiftMaster where 
		([ShiftFrom]<[ShiftTo] AND @TimeToCheck>=[ShiftFrom] AND @TimeToCheck<=[ShiftTo]) OR 
		([ShiftFrom]>[ShiftTo] AND (@TimeToCheck>=[ShiftFrom] OR @TimeToCheck<=[ShiftTo]))

		if (@RetCode is null)
			set @RetCode ='Z'

			RETURN @RetCode
	END
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 09-03-2023 10:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[Split](@String varchar(MAX), @Delimiter char(1))       
returns @temptable TABLE (items varchar(MAX))       
as       
begin      
    declare @idx int       
    declare @slice varchar(8000)       

    select @idx = 1       
        if len(@String)<1 or @String is null  return       

    while @idx!= 0       
    begin       
        set @idx = charindex(@Delimiter,@String)       
        if @idx!=0       
            set @slice = left(@String,@idx - 1)       
        else       
            set @slice = @String       

        if(len(@slice)>0)  
            insert into @temptable(Items) values(@slice)       

        set @String = right(@String,len(@String) - @idx)       
        if len(@String) = 0 break       
    end   
return 
end;

GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 09-03-2023 10:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]  
(  
   @Input NVARCHAR(MAX),  
   @Character CHAR(1)  
)  
RETURNS @Output TABLE (  
   Item NVARCHAR(1000)  
)  
AS  
BEGIN  
DECLARE @StartIndex INT, @EndIndex INT  
SET @StartIndex = 1  
IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character  
BEGIN  
SET @Input = @Input + @Character  
END  
WHILE CHARINDEX(@Character, @Input) > 0  
BEGIN  
SET @EndIndex = CHARINDEX(@Character, @Input)  
INSERT INTO @Output(Item)  
SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)  
SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))  
END  
RETURN 
END  

GO
/****** Object:  Table [dbo].[TBL_AssetApprove]    Script Date: 09-03-2023 10:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_AssetApprove](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocNo] [varchar](20) NOT NULL,
	[Plant] [varchar](20) NOT NULL,
	[AssetCode] [varchar](50) NOT NULL,
	[DispQty] [decimal](18, 0) NOT NULL,
	[Description] [varchar](50) NULL,
	[MovementType] [varchar](50) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_AssetMaster]    Script Date: 09-03-2023 10:39:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_AssetMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlantCode] [varchar](50) NULL,
	[Floor] [varchar](20) NOT NULL,
	[Section] [varchar](50) NOT NULL,
	[AssetCode] [varchar](100) NOT NULL,
	[Description] [varchar](100) NULL,
	[RFID_Tag] [varchar](100) NULL,
	[Brand] [varchar](50) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
	[LocationCode] [varchar](50) NULL,
	[DeptCode] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_AssetMaster] PRIMARY KEY CLUSTERED 
(
	[AssetCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_AssetMovement]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_AssetMovement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocNo] [varchar](20) NOT NULL,
	[FromPlant] [varchar](20) NOT NULL,
	[FromFloor] [varchar](50) NOT NULL,
	[FromSection] [varchar](50) NOT NULL,
	[ToPlant] [varchar](20) NOT NULL,
	[ToFloor] [varchar](50) NOT NULL,
	[ToSection] [varchar](50) NOT NULL,
	[AssetCode] [varchar](50) NOT NULL,
	[Qty] [decimal](18, 0) NOT NULL,
	[ApproveStatus] [varchar](1) NULL,
	[MovementType] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveOn] [datetime] NULL,
 CONSTRAINT [PK_TBL_AssetMovement] PRIMARY KEY CLUSTERED 
(
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_GroupMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_GroupMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](20) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[Sitecode] [varchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[GroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_GroupRight]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_GroupRight](
	[GroupName] [varchar](20) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[View] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](20) NULL,
	[Add] [bit] NULL,
	[Update] [bit] NULL,
	[Delete] [bit] NULL,
 CONSTRAINT [PK_UserTypeRight] PRIMARY KEY CLUSTERED 
(
	[GroupName] ASC,
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_ModuleMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ModuleMaster](
	[ModuleId] [int] NOT NULL,
	[ModuleName] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ScreenMaster] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_PlantMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_PlantMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlantCode] [varchar](20) NOT NULL,
	[Floor] [varchar](50) NOT NULL,
	[Section] [varchar](50) NOT NULL,
	[LocationCode] [varchar](50) NOT NULL,
	[DptCode] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_TBL_PlantMaster_1] PRIMARY KEY CLUSTERED 
(
	[PlantCode] ASC,
	[Floor] ASC,
	[Section] ASC,
	[LocationCode] ASC,
	[DptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_RunningSerial]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_RunningSerial](
	[TranType] [varchar](50) NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[Day] [int] NULL,
	[SerialNo] [int] NULL,
	[Hours] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[LotNo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_UserMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_UserMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](10) NOT NULL,
	[GroupName] [varchar](20) NOT NULL,
	[EmailID] [varchar](100) NULL,
	[PlantCode] [varchar](20) NULL,
	[Line] [varchar](20) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](20) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Version]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Version](
	[AppName] [nvarchar](50) NULL,
	[App_Version] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_GroupRight] ADD  CONSTRAINT [DF_TBL_GroupRight_Add]  DEFAULT ((0)) FOR [Add]
GO
ALTER TABLE [dbo].[TBL_GroupRight] ADD  CONSTRAINT [DF_TBL_GroupRight_Update]  DEFAULT ((0)) FOR [Update]
GO
ALTER TABLE [dbo].[TBL_GroupRight] ADD  CONSTRAINT [DF_TBL_GroupRight_Delete]  DEFAULT ((0)) FOR [Delete]
GO
ALTER TABLE [dbo].[TBL_ModuleMaster] ADD  CONSTRAINT [DF_ModuleMaster_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  StoredProcedure [dbo].[PRC_AssetApprove]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_AssetApprove]
@Type varchar(100),
@DocNo	varchar(20),
@Plant	varchar(20),
@AssetCode	varchar(50),
@Qty	decimal(18, 0),
@MovementType varchar(50) = NULL,
@CreatedBy varchar(50) = NULL
AS
BEGIN

 IF @TYPE='GET_PLANT'
		  BEGIN
			 SELECT Distinct PlantCode from TBL_PlantMaster
	   END
	   IF @TYPE='GET_DOC_NO'
		  BEGIN
			 SELECT Distinct DocNo from TBL_AssetMovement where FromPlant=@Plant and isnull( ApproveStatus,'N')<>'Y'
	   END
   if(@Type='SELECT')
	  begin
		SELECT 
		FromPlant,AM.AssetCode,am.Description as AssestName,Qty
		FROM TBL_AssetMovement AMM
		inner join TBL_AssetMaster AM on AMM.AssetCode=AM.AssetCode
		where isnull( ApproveStatus,'N')<>'Y' and DocNo=@DocNo ORDER BY DocNo

		
	  end

	if(@Type='INSERT')
	    BEGIN  
		  INSERT INTO TBL_AssetApprove (DocNo,Plant,AssetCode,DispQty,CreatedBy,CreatedOn)
		  VALUES(@DocNo,@Plant,@AssetCode,@Qty,@CreatedBy,getdate())

		 update TBL_AssetMovement set ApproveStatus='Y' , MovementType=@MovementType where DocNo=@DocNo and FromPlant=@Plant
		 Select 'Y' AS RESULT
		END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_AssetMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PRC_AssetMaster]
@TYPE NVARCHAR(100),
@PlantCode	varchar(20)	=NULL,
@Floor	varchar(20)	=NULL,
@Section	varchar(50)=NULL,
@AssetCode	varchar(100)	=NULL,
@Description	varchar(100)	=NULL,
@RFID_Tag	varchar(100)	=NULL,
@Brand	varchar(100)=NULL,
@CreatedBy	varchar(20)	=NULL,
@ID int

AS 
BEGIN
  BEGIN TRY
    IF @TYPE='SELECT'
	  BEGIN
		 SELECT PlantCode,
			Floor,
			Section,
			AssetCode	,
			Description	,
			RFID_Tag	,
			Brand,
			CreatedBy,
			CreatedOn,
			ID as AssetID
		 FROM TBL_AssetMaster
	  END
	  
	   IF @TYPE='GET_PLANT'
		  BEGIN
			 SELECT Distinct PlantCode from TBL_PlantMaster
	   END
	   IF @TYPE='GET_FLOOR'
		  BEGIN
			 SELECT Distinct Floor from TBL_PlantMaster where PlantCode=@PlantCode
	   END
		 IF @TYPE='GET_SECTION'
		  BEGIN
			 SELECT Distinct Section from TBL_PlantMaster where PlantCode=@PlantCode and Floor=@Floor
	   END

	    IF @TYPE='GET_FLOOR1'
		  BEGIN
			 SELECT Distinct Floor from TBL_PlantMaster
	   END
		 IF @TYPE='GET_SECTION1'
		  BEGIN
			 SELECT Distinct Section from TBL_PlantMaster 
	   END


    IF @TYPE='INSERT'
	  BEGIN
	      IF EXISTS(SELECT 1 FROM TBL_AssetMaster WHERE AssetCode=@AssetCode and PlantCode=@PlantCode and Floor=@Floor and Section=@Section)
		   BEGIN
		     Select 'This Asset Code is already exists!!!!' AS RESULT
			 RETURN
		   END
	      INSERT INTO TBL_AssetMaster
            (PlantCode,
			Floor,
			Section,
			AssetCode	,
			Description	,
			RFID_Tag	,
			Brand,
			CreatedBy,
			CreatedOn)
         VALUES
           (@PlantCode,
			@Floor,
			@Section,
			@AssetCode	,
			@Description	,
			@RFID_Tag	,
			@Brand,
			@CreatedBy,
			Getdate())
		   Select 'Y' AS RESULT
	  END
	
	 IF @TYPE='UPDATE'
	  BEGIN
	      
		   update TBL_AssetMaster set [Description]=@Description , PlantCode=@PlantCode , Floor=@Floor , Section=@Section,RFID_Tag=@RFID_Tag, ModifiedBy=@CreatedBy,ModifiedOn=GETDATE() where AssetCode=@AssetCode
	     
		   Select 'Y' AS RESULT
	  END

	IF @TYPE='DELETE'
	  BEGIN
	     DELETE FROM TBL_AssetMaster WHERE ID=@ID
		 Select 'Y' AS RESULT
	  END
   	END TRY
		 BEGIN CATCH
				SELECT 
				ERROR_MESSAGE() AS ErrorMessage;
		 END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[PRC_AssetMovement]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_AssetMovement]
@Type varchar(100),
@DocNo	varchar(20),
@FromPlant	varchar(20),
@FromFloor	varchar(50),
@FromSection	varchar(50),
@ToPlant	varchar(20),
@ToFloor	varchar(50),
@ToSection	varchar(50),
@AssetCode	varchar(50),
@Qty	decimal(18, 0),
@Description	varchar(50)		=null,
@CreatedBy varchar(50) = NULL
AS
BEGIN

 IF @TYPE='GET_PLANT'
		  BEGIN
			 SELECT Distinct PlantCode from TBL_PlantMaster
	   END
	   IF @TYPE='GET_FLOOR'
		  BEGIN
			 SELECT Distinct Floor from TBL_PlantMaster where PlantCode=@FromPlant
	   END
		 IF @TYPE='GET_SECTION'
		  BEGIN
			 SELECT Distinct Section from TBL_PlantMaster where PlantCode=@FromPlant and Floor=@FromFloor-- and Section=@ToSection
	   END

	    IF @TYPE='GET_AssetCode'
		  BEGIN
			 SELECT distinct AssetCode from TBL_AssetMaster --where PlantCode=@FromPlant and Floor=@FromFloor and Section=@ToSection
	   END

	if(@Type='SELECT')
	  begin
		SELECT DISTINCT CAST('FALSE' AS BIT) AS IsValid,
			DocNo,
			CreatedBy,
			convert(varchar, CreatedOn, 103) CreatedOn
		FROM TBL_AssetMovement
		where isnull(ApproveStatus,'N')<>'Y'
		ORDER BY DocNo
	  end
   
   if(@Type='GETPICKLISTDETAILS')
	  begin
		SELECT 
		DocNo DocNo1,FromPlant,FromFloor,FromSection,ToPlant,ToFloor,ToSection,AM.AssetCode,Qty,''DeletePart
		FROM TBL_AssetMovement AMM
		inner join TBL_AssetMaster AM on AMM.AssetCode=AM.AssetCode
		where  isnull(ApproveStatus,'N')<>'Y' and DocNo=@DocNo ORDER BY DocNo
	  end

	if(@Type='INSERT')
	    BEGIN  
		  INSERT INTO TBL_AssetMovement (DocNo,FromPlant,FromFloor,FromSection,ToPlant,ToFloor,ToSection,AssetCode,Qty,Description,CreatedBy,CreatedOn,ApproveStatus)
		  VALUES
			   (@DocNo,@FromPlant,@FromFloor,@FromSection,@ToPlant,@ToFloor,@ToSection,@AssetCode,@Qty,@Description,@CreatedBy,getdate(),'N')
			    Select 'Y' AS RESULT
		END
	  
 if(@Type='UPDATE')
	  begin
	  IF(Exists(SELECT 1 FROM  TBL_AssetMovement  WHERE  DocNo = @DocNo and isnull(ApproveStatus,'N')='N'))
       BEGIN
	   UPDATE TBL_AssetMovement SET
	   Qty=@Qty,
	   ModifiedBy = @CreatedBy,
	   ModifiedOn = getdate()
	   where DocNo = @DocNo
	   and AssetCode = @AssetCode 
	   and FromPlant = @FromPlant
	   and FromFloor=@FromFloor
	   and FromSection=@FromSection
	   and ToPlant = @ToPlant
	   and ToFloor=@ToFloor
	   and ToSection=@ToSection
	   and isnull(ApproveStatus,'N')<>'Y'
	   Select 'Y' AS RESULT
	   end
	   ELSE
	   BEGIN
	      Select 'N' As Result,'Doc No ('+@DocNo+') is Approved ,So your can not update after approved' as Msg
	   END
	 end
 if(@Type='DELETE')
	  begin
	  IF(Exists(SELECT 1 FROM  TBL_AssetMovement  WHERE  DocNo = @DocNo and isnull(ApproveStatus,'N')='N'))
	    begin
			DELETE TBL_AssetMovement
			where DocNo = @DocNo
			and AssetCode = @AssetCode 
			and isnull(ApproveStatus,'')<>'Y'
			Select 'Y' AS RESULT
		end
		else
		begin
		    Select 'N' As Result,'Doc No ('+@DocNo+') is Approved ,So your can not delete after approved' as Msg
		end
	  end
  if(@Type='CHECKDUP')
	  begin
	   SELECT DocNo FROM TBL_AssetMovement WHERE DocNo = @DocNo and AssetCode = @AssetCode
	  end
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_BIND_COMBO]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PRC_BIND_COMBO]
@TYPE NVARCHAR(100)
AS
BEGIN
 DECLARE @QUERY NVARCHAR(MAX)=NULL;
   IF @TYPE='SELECT_GROUP'
     BEGIN
        SET @QUERY='SELECT GroupName FROM TBl_GroupMaster Order By GroupName'
		 EXEC(@QUERY)
	 END
   IF @TYPE='BIND_PART'
     BEGIN
	    SET @QUERY='SELECT PART_NO,PART_NO FROM TBL_PART_MASTER'
		EXEC(@QUERY)
	 END
   IF @TYPE='BIND_OPERATOR'
     BEGIN
	    SET @QUERY='SELECT UserName,UserName FROM TBL_UserMaster'
		EXEC(@QUERY)
	 END
   IF @TYPE='BIND_CUSTOMER'
     BEGIN
	    SET @QUERY='SELECT CUST_CODE,CUST_NAME FROM TBL_CUSTOMER_MASTER'
		EXEC(@QUERY)
	 END
	
END




GO
/****** Object:  StoredProcedure [dbo].[PRC_GET_VERSION]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[PRC_GET_VERSION]
@APP_NAME NVARCHAR(10),
@APP_VERSION NVARCHAR(100)
AS
BEGIN
   DECLARE @DB_APP_VERSION NVARCHAR(100)=NULL
   IF NOT EXISTS(SELECT App_Version FROM TBL_Version WHERE  AppName=@APP_NAME AND App_Version=@APP_VERSION )
     BEGIN
	    SELECT @DB_APP_VERSION =MAX(App_Version) FROM TBL_Version WHERE  AppName=@APP_NAME 
		
	    SELECT 'New application version('+cast( @DB_APP_VERSION as varchar)+') and your application version is ('+cast(@APP_VERSION as varchar)+'). Kindly update with new version!!!!!!'  ;
	 END
   else
     SELECT 'OK'
END





GO
/****** Object:  StoredProcedure [dbo].[PRC_GetRunningSerial]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRC_GetRunningSerial]
                @TrnType VARCHAR(50)--,
				--@RESULT VARCHAR(MAX) OUTPUT
                
AS
BEGIN
                DECLARE @SERIAL AS BIGINT
                DECLARE @RESPONSE AS VARCHAR(max)
				--DECLARE @Barcode AS VARCHAR(30)
                DECLARE @YEAR AS INT
                DECLARE @MONTH AS INT
                DECLARE @DAY AS INT
               
--BEGIN TRAN
 
                SELECT @YEAR=ISNULL([YEAR],0),@MONTH=ISNULL([MONTH],0),@DAY=ISNULL([DAY],0) FROM TBL_RunningSerial
                WHERE [YEAR]=RIGHT(YEAR(GETDATE()),4) AND [MONTH]=MONTH(GETDATE()) AND [DAY]=RIGHT('00'+CAST(DAY(GETDATE()) AS VARCHAR(2)),2)
                AND TranType=@TrnType
 
              --  IF (@@ERROR <> 0) GOTO PROBLEM     
                IF @YEAR>0
                                BEGIN
                                IF @MONTH>0
                                                BEGIN  
                                                                UPDATE TBL_RunningSerial
                                                                SET @SERIAL = SERIALNo + 1,
                                                                SERIALNo = SERIALNo + 1
                                                                WHERE TranType=@TrnType
                                                                AND [YEAR]=@YEAR
                                                                AND [MONTH]=@MONTH          
                                                                AND [DAY]=@DAY
                                                               -- IF (@@ERROR <> 0) GOTO PROBLEM     
                                                END      
                                ELSE
                                                BEGIN
                                                                INSERT INTO TBL_RunningSerial
                                                                ([YEAR],[MONTH],[DAY],TRANTYPE,SERIALNo)
                                                                VALUES
                                                                (RIGHT(YEAR(GETDATE()),4),MONTH(GETDATE()),DAY(GETDATE()),@TrnType,1)
                                                                SET @SERIAL = 1
                                                                SET @YEAR=RIGHT(YEAR(GETDATE()),2)
                                                                SET @MONTH=MONTH(GETDATE())      
                                                                SET @DAY=RIGHT('00'+CAST(DAY(GETDATE()) AS VARCHAR(2)),2)
                                                               -- IF (@@ERROR <> 0) GOTO PROBLEM     
                                                END
                                END
                ELSE
                                BEGIN
                                                INSERT INTO TBL_RunningSerial
                                                ([YEAR],[MONTH],[DAY],TRANTYPE,SERIALNo)
                                                VALUES
                                                (RIGHT(YEAR(GETDATE()),4),MONTH(GETDATE()),DAY(GETDATE()),@TrnType,1)
                                                SET @SERIAL = 1
                                                SET @YEAR=RIGHT(YEAR(GETDATE()),2)
                                                SET @MONTH=MONTH(GETDATE())      
                                                SET @DAY=RIGHT('00'+CAST(DAY(GETDATE()) AS VARCHAR(2)),2)
                                               -- IF (@@ERROR <> 0) GOTO PROBLEM
                                END
                                               
   IF @TrnType=@TrnType
         BEGIN
           SET @RESPONSE=  RIGHT('00'+CAST(@DAY AS VARCHAR(2)),2)+RIGHT('00'+CAST(@MONTH AS VARCHAR(2)),2)+RIGHT('00'+CAST(@YEAR AS VARCHAR(4)),2)+ RIGHT('0000'+CAST(@SERIAL AS VARCHAR(4)),4)
		  -- SET @RESPONSE=  RIGHT('00000'+CAST(@SERIAL AS VARCHAR(5)),5)
		 select @RESPONSE as Barcode
         END
   
                   
--COMMIT TRAN
--set @RESULT=Upper((@RESPONSE))
--PROBLEM:
--                IF (@@ERROR <> 0)
--                BEGIN
--                                ROLLBACK TRAN
--                END
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_GroupMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PRC_GroupMaster] 
@Type varchar(100),
@GroupName varchar(20)=null,
@ModuleId int=null,
@CreatedBy varchar(20)=null,
@View bit=0,
@Add bit=0,
@Update bit=0,
@Delete bit=0
	AS
	Begin
	 DECLARE @Query nvarchar(max)=null;
	if(@Type='SELECT')
	  begin
		Select GroupName,CreatedBy,CONVERT(varchar(10),CreatedOn,103) CreatedOn
			  from TBL_GroupMaster where IsActive='True' Order By GroupName
		Select ModuleId,ModuleName From TBL_ModuleMaster Where Active = 'True' Order By ModuleId
	  end
	else if(@Type='SELECTBYID')
	  begin
			Select ModuleId,[View],[Add],[Update],[Delete] From TBL_GroupRight Where GroupName = @GroupName
	  end	  
	else if(@Type='INSERT')
	  begin
	 
	    Insert Into TBL_GroupMaster (GroupName,IsActive,CreatedBy,CreatedOn)
	    values(@GroupName,'True',@CreatedBy,GETDATE())
	    
		Select 'SUCCESS'
		end
	  else if(@Type='INSERT_GROUP_RIGHT')
	  begin
	    INSERT INTO [dbo].[TBL_GroupRight]
           ([GroupName]
           ,[ModuleId]
		   ,[View]
		   ,[Add]
		   ,[Update]
		   ,[Delete]
           ,[CreatedOn]
           ,[CreatedBy]) VALUES(@GroupName,@ModuleId,@View,@Add,@Update,@Delete,GETDATE(),@CreatedBy)
		 Select 'SUCCESS'
	  end
	else if(@Type='DELETE_GROUP_RIGHT')
	  begin
	    Delete From TBL_GroupRight Where GroupName = @GroupName
		 Select 'SUCCESS'
	  end

	   else if(@Type='GET_USER_RIGHTS')
		  begin
		        set @Query='
				Select ModuleId From TBL_GroupRight'
				if @GroupName !='ADMIN'
				  begin
				    set @Query=@Query+' Where GroupName = '''+@GroupName+''''
				  end
				exec(@Query)
		  end		

	else if(@Type='DELETE')
	  begin
		  Begin Try
			Begin Tran
				 update TBL_GroupMaster set IsActive='false'
				 WHERE GroupName=@GroupName

				 delete from TBL_GroupRight  Where GroupName = @GroupName

				 Select 'SUCCESS'
			Commit Tran
		End Try
		Begin Catch
			Rollback Tran
			Select 'DB Error-'+  ERROR_MESSAGE()
		End Catch
	  end
	
  End














GO
/****** Object:  StoredProcedure [dbo].[PRC_PlantMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PRC_PlantMaster]
@TYPE NVARCHAR(100),
@PlantCode	varchar(20)	=NULL,
@Floor	varchar(50)=NULL,
@Section		varchar(50)=NULL,
@LocationCode varchar (100),
@DptCode varchar (100),
@Description varchar (100),
@CreatedBy	varchar(20)	=NULL,
@ID  int=0
AS 
BEGIN
  BEGIN TRY
    IF @TYPE='SELECT'
	  BEGIN
		 SELECT PlantCode,
			Floor,
			Section,
			LocationCode,
			DptCode,
			Description,
			ID	,
			CreatedBy,
			CreatedOn
		 FROM TBL_PlantMaster
	  END
    IF @TYPE='INSERT'
	  BEGIN
	      IF EXISTS(SELECT 1 FROM TBL_PlantMaster WHERE PlantCode=@PlantCode and Floor=@Floor and Section=@Section and LocationCode=@LocationCode and DptCode=@DptCode )
		   BEGIN
		      Select 'This Plant is already exists!!!!' AS RESULT
			 RETURN
		   END
	      INSERT INTO TBL_PlantMaster
           (PlantCode,
		    Floor,
			Section,
			LocationCode,
			DptCode,
			Description,
			CreatedBy,
			CreatedOn)
         VALUES
           (@PlantCode,
		    @Floor,
			@Section,
			@LocationCode,
			@DptCode,
			@Description,
			@CreatedBy,
			getdate())
		   Select 'Y' AS RESULT
	  END

	    IF @TYPE='UPDATE'
	  BEGIN
	      
	       update TBL_PlantMaster set [Description]=@Description ,ModifiedBy=@CreatedBy,ModifiedOn=GETDATE() where ID=@ID and PlantCode=@PlantCode and Floor=@Floor and Section=@Section
		   Select 'Y' AS RESULT
	  END
	
	IF @TYPE='DELETE'
	  BEGIN
	     DELETE FROM TBL_PlantMaster WHERE ID=@ID
		 Select 'Y' AS RESULT
	  END
	  IF @TYPE='CHECK_DUPLICATE'
	  BEGIN
	     IF EXISTS(SELECT 1 FROM TBL_PlantMaster WHERE PlantCode=@PlantCode and Floor=@Floor and Section=@Section and LocationCode=@LocationCode and DptCode=@DptCode )
		   BEGIN
		     Select 'Y' AS RESULT
		   END
		   ELSE
		   BEGIN
		     Select 'N' AS RESULT
		  END
		
	  END

   	END TRY
		 BEGIN CATCH
				SELECT 
				ERROR_MESSAGE() AS ErrorMessage;
		 END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[PRC_REPORT]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PRC_REPORT]
@TYPE VARCHAR(100)=NULL,
@FROM_DATE VARCHAR(50)=NULL,
@TO_DATE VARCHAR(50)=NULL,
@PartNo VARCHAR(50)=NULL,
@LineNo VARCHAR(50)=NULL,
@ReportType VARCHAR(50)=NULL

AS
BEGIN

 DECLARE @QUERY NVARCHAR(MAX)=NULL
  IF @TYPE='GET_PARTNO'
    BEGIN
	  SELECT  ProductCode FROM TBL_PartMaster
	END

	 IF @TYPE='GET_LINE'
    BEGIN
	  SELECT  Line_No FROM TBL_LineMaster
	END

  IF @TYPE='GET_BARCODE_DATA'
    BEGIN
	   if (@ReportType='P')
	    begin
			select  Line_No as 'Line',SetDefaultProduct 'Product Code',ProductQRCode 'Product QR Code', (case when IsCompleted='Y' then 'Completed' else 'Not Completed' end) Completed,Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_ProductQRScanning
			where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
			union
			select Line_No as 'Line',SetDefaultProduct 'Product Code',ProductQRCode 'Product QR Code', '' Completed,Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_ProductQRScanning_H
			where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
			--order by CreatedOn desc
		end
		else  if (@ReportType='M')
		begin
		 select Line_No as 'Line',SetDefaultProduct 'Product Code',EAN_No 'EAN QR Code', (case when IsCompleted='Y' then 'Completed' else 'Not Completed' end) Completed, Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_MRPQRScanning
		  where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
		  union
		  select Line_No as 'Line',SetDefaultProduct 'Product Code',EAN_No 'EAN QR Code', '' Completed, Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_MRPQRScanning_H
		  where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
		  --order by CreatedOn desc
		end
		else
		begin
		 select  Line_No as 'Line',SetDefaultProduct 'Product Code',EAN_No 'EAN QR Code', (case when IsCompleted='Y' then 'Completed' else 'Not Completed' end) Completed, Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_MasterCartonScanning
		 where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
		 union
		 select Line_No as 'Line',SetDefaultProduct 'Product Code',EAN_No 'EAN QR Code', '' Completed, Status,CreatedOn 'Scanned On',CreatedBy 'Scanned By' from TBL_MasterCartonScanning_H
		 where ((@PartNo  ='') or( SetDefaultProduct=@PartNo)) and ((@LineNo  ='') or( Line_No=@LineNo)) and CONVERT(VARCHAR(10),CreatedOn,121) BETWEEN @FROM_DATE AND @TO_DATE
		 --order by CreatedOn desc
		end
	END
END


GO
/****** Object:  StoredProcedure [dbo].[PRC_SET_CHILDSEC_RIGHTS]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PRC_SET_CHILDSEC_RIGHTS] 
@GROUP_NAME NVARCHAR(50)=NULL,
@MODULE_NAME NVARCHAR(100)=NULL
AS
BEGIN
  
SELECT distinct [Add] as [Save],[Update],[Delete]  FROM TBL_GROUPRIGHT GR JOIN TBL_MODULEMASTER MD ON GR.MODULEID=MD.MODULEID
WHERE MODULENAME='Part Master' AND GroupName='User'
	
END




GO
/****** Object:  StoredProcedure [dbo].[PRC_UserMaster]    Script Date: 09-03-2023 10:39:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[PRC_UserMaster] 
@Type varchar(max),
@UserID nvarchar(50)=null,
@UserName nvarchar(150)=null,
@Password nvarchar(50)=null,
@Group nvarchar(50)=null,
@CreatedBy nvarchar(50)=null,
@NewPassword nvarchar(50)=null,
@EmailId nvarchar(100)=null,
@EmpCode nvarchar(100)=null,
@Line nvarchar(100)=null,
@EmpDesignation nvarchar(100)=null,
@PlantCode nvarchar(100)=null

AS
BEGIN
	Declare @Count int;
	 DECLARE @QUERY NVARCHAR(MAX)=NULL;
	if (@Type = 'SELECT')
		begin
			 SELECT USERID,USERNAME,PASSWORD,EmailId,PlantCode ,GROUPNAME,Line,CreatedBy,CONVERT(varchar(10),CreatedOn,103) CreatedOn
			 FROM TBL_UserMaster us where IsActive='True'
			 ORDER BY USERNAME

		end

    if (@Type = 'GetPlant')
		begin
			select Distinct PlantCode from TBL_PlantMaster
		end
	
	else if (@Type = 'SEARCH')
		begin
			SELECT USERID,USERNAME,PASSWORD,EmailId,PlantCode,GROUPNAME,Line,CreatedBy,CONVERT(varchar(10),CreatedOn,103) CreatedOn 
			FROM TBL_UserMaster us
			WHERE IsActive='True' and USERID like '%'+CAST(@UserID AS nvarchar)+'%' or  UserName like '%'+CAST(@UserID AS nvarchar)+'%'
		
		end
	else if(@Type='SELECTBYID')
	  begin
		 SELECT USERID,USERNAME,PASSWORD,EmailId,PlantCode,GROUPNAME,Line,CreatedBy,CONVERT(varchar(10),CreatedOn,103) CreatedOn
		 FROM TBL_UserMaster us 
		 WHERE IsActive='True'  and USERID = ''+CAST(@UserID AS nvarchar)+''
	  end
	else if(@Type='INSERT')
	  begin
	    IF EXISTS(SELECT 1 FROM TBL_UserMaster WHERE UserId=@UserID)
		 BEGIN
		     Select 'This user id is already exists!!!!' AS RESULT
			 RETURN
		 END
	    INSERT INTO [dbo].[TBL_UserMaster]
           ([UserId]
           ,[UserName]
           ,[Password]
           ,[EmailId]
		   ,[PlantCode]
		   ,[GroupName]
		   ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy])
		 VALUES
           (@UserID
           ,@UserName
           ,@Password
		   ,@EmailId
		   ,@PlantCode
           ,@Group
		   ,'True'
           ,GETDATE()
           ,@CreatedBy)

			Select 'Y' AS RESULT
	  end
	 else if(@Type='UPDATE')
	  begin
	     UPDATE [dbo].[TBL_UserMaster]
		   SET [UserName] = @UserName
			  ,[Password] = @Password
			  ,[GroupName] = @Group
			  ,[EmailId] = @EmailId
			  ,[PlantCode] = @PlantCode
			  ,ModifiedOn=getdate()
			  ,ModifiedBy=@CreatedBy
		 WHERE UserId = @UserId 
		 Select 'Y' AS RESULT
	  end
	else if(@Type='DELETE')
	  begin
	     Update [TBL_UserMaster] set IsActive='false' ,ModifiedOn=getdate() ,ModifiedBy=@CreatedBy WHERE UserId=@UserID 
		 Select 'Y' AS RESULT
	  end
	
	else if (@Type='VALIDATEUSER') 
		    begin
			      Select distinct UserName,GroupName,USERID,PlantCode From TBL_UserMaster
				  Where UserId = @UserID And Password = @Password and PlantCode=@PlantCode
		    end
    else if (@Type='ACCESSUSER') 
		    begin
			   if exists(select UserID from TBL_UserMaster where UserId = @UserID And Password = @Password AND GroupName in ('ADMIN','SUPERVISOR'))
			     begin
				      DECLARE @MSG_RS nvarchar(50)=null
					  Select distinct @MSG_RS=UserName From TBL_UserMaster
					   Where UserId = @UserID And Password = @Password 
					  Select 'Y' AS RESULT,@MSG_RS AS MSG
				 end
			   else
			      Select 'N' AS RESULT,'Only Admin/Supervisor can give the access!!' AS MSG
		    end
	else if (@Type='UPDATEPASSWORD')
		begin
			Declare @UserOldPassword varchar(50)
			Select @UserOldPassword = Password From TBL_UserMaster Where UserId = @UserID
		
			If(@Password = @UserOldPassword)
			Begin
				UPDATE TBL_UserMaster set PASSWORD = @NewPassword, ModifiedOn=getdate() ,ModifiedBy=@CreatedBy where  UserId=@UserID
				Select 'Y' AS RESULT
			End
			Else
			Begin
				Select 'Wrong Old Password' AS RESULT
			End
		end

END


GO
