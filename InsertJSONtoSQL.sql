INSERT INTO Comments(id, parent_id, link_id, name, author, body, subreddit_id, subreddit, score, created_utc)
 SELECT id, parent_id, link_id, name, author, body, subreddit_id, subreddit, score, created_utc
 FROM OPENROWSET (BULK 'C:\JSON\RC_2011-07_08', SINGLE_CLOB) as j
 CROSS APPLY OPENJSON(BulkColumn)
 WITH( id nvarchar(100), parent_id nvarchar(100), link_id NVARCHAR(100), 
	 name nvarchar(100), author nvarchar(100), body varchar(MAX),
	 subreddit_id nvarchar(100), subreddit nvarchar(100), 
	 score int, created_utc BIGINT)