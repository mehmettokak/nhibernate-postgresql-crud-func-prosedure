CREATE TABLE personprofil (
	personprofilid integer NOT NULL GENERATED ALWAYS AS IDENTITY,
	firstname varchar(50) NOT NULL,
	lastname varchar(50) NULL,
	CONSTRAINT personprofil_pkey PRIMARY KEY (personprofilid)
);


insert into personprofil (firstname,lastname) values 
													 ('Murat','TOKAK'),
													 ('Süleyman','TOKAK'),
													 ('Ali','TOKAK'),
													 ('Veli','TOKAK'),
													 ('Ahmet','TOKAK'),
													 ('Esat','TOKAK'),
													 ('Baran','TOKAK'),
													 ('Berfin','TOKAK');
													 
													
create or replace function getpersonlist()
	returns table
( personprofilid1 integer , firstname1 varchar, lastname1 varchar )
as $$
begin 
	return Query
	select personprofilid,firstname,lastname from personprofil ;
	
end $$ language 'plpgsql';

select * from getpersonlist()

select * from personprofil p 


create or replace procedure addpersonel(firstname in varchar(50),lastname in varchar(50),resultText inout varchar)
as $$
declare
begin
	
	insert  into  personprofil (firstname,lastname) values(firstname,lastname);
	
resultText=concat(firstname,' ',lastname,' kayýt eklendi');
end 
$$ language 'plpgsql';


call addpersonel('ali3','sunal3',null);




create or replace function addpersonelf(firstname in varchar(50),lastname in varchar(50))
returns varchar(100) 
as $$
declare rslt varchar(100);
begin 
	insert  into  personprofil (firstname,lastname) values(firstname,lastname);
rslt=concat(firstname,' ',lastname,' kayýt eklendi');
	return  rslt;
end $$ language 'plpgsql';


select * from addpersonelf('ali1','sunal1')

create or replace function updatepersonelf(id in int4,fname in varchar(50),lname in varchar(50))
returns varchar(100) 
as $$
declare rslt varchar(100);
begin 
	update personprofil set firstname=fname,lastname=lname where personprofilid=id;
rslt=concat(fname,' ',lname,' kayýt güncellendi. (F)');
	return  rslt;
end $$ language 'plpgsql';

select * from updatepersonelf(3,'ali3','tokak3')


create or replace procedure updatepersonelp(id in int4,fname in varchar(50),lname in varchar(50),resultText inout varchar)
as $$
declare
begin
	
	update personprofil set firstname=fname,lastname=lname where personprofilid=id;
	
resultText=concat(fname,' ',lname,' kayýt guncellendi.(P)');
end 
$$ language 'plpgsql';

call updatepersonelp(5,'ahmet5','tokak5',null);


-----delete function
create or replace function deletepersonelf(id in int4)
returns varchar(100) 
as $$
declare rslt varchar(100);
begin 
	delete from personprofil where personprofilid=id;
rslt=concat('personprofilid= ',id,' olan  kayýt silindi. (F)');
	return  rslt;
end $$ language 'plpgsql';

select * from deletepersonelf(4)



--delete prosedure
create or replace procedure deletepersonelp(id in int4,resultText inout varchar)
as $$
declare
begin
	
	delete from personprofil where personprofilid=id;
	
resultText=concat('personprofilid= ',id,' olan  kayýt silindi. (P)');
end 
$$ language 'plpgsql';

call deletepersonelp(5,null);

