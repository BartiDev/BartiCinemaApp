CREATE FUNCTION [dbo].[ufn_GetObjectInfo]
(
	@ObjectName NVARCHAR(128)
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
	   SCHEMA_NAME(SCHEMA_ID) AS [Schema]
	  ,SO.name AS [ObjectName]			   
	  ,SO.Type_Desc AS [ObjectType]
	  ,P.parameter_id AS [ParameterId]
	  ,P.name AS [ParameterName]
	  ,TYPE_NAME(P.user_type_id) AS [ParameterDataType]
	  ,P.max_length AS [ParameterMaxBytes]
	  ,P.is_output AS [IsOutputParameter]
	FROM sys.objects AS SO
	INNER JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
	WHERE SO.name = @ObjectName
)