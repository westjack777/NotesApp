if not exists (select 1 from dbo.[Notes])
begin
	insert into dbo.[Notes] (Description)
	values ('Do Laundry'), ('Buy Fruits'), ('Pay Bills');
end