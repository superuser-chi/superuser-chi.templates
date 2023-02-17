USE [Canteen_DB]
GO

UPDATE [dbo].[MeetingParticipants]
   SET 
      [HasOrdered] = 0
  WHERE [MeetingID] = <MeetingID> AND
   [UserID] = <UserID>
GO