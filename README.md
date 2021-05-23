# nhibernate-postgresql-crud-func-prosedure
.Net5 &amp;&amp; Nhibernate &amp;&amp; PostgreSql Use Func and Prosedure &amp;&amp;Crud Action


postgre sql tablo oluşturma,presdure ve function oluşturma scriptler:

CREATE TABLE personprofil (
	personprofilid integer NOT NULL GENERATED ALWAYS AS IDENTITY,
	firstname varchar(50) NOT NULL,
	lastname varchar(50) NULL,
	CONSTRAINT personprofil_pkey PRIMARY KEY (personprofilid)
);


insert into personprofil (firstname,lastname) values 
													 ('Mehmet','TOKAK'),
													 ('Mehmet1','TOKAK'),
													 ('Mehmet2','TOKAK'),
													 ('Mehmet3','TOKAK'),
													 ('Mehmet4','TOKAK'),
													 ('Mehmet5','TOKAK'),
													 ('Mehmet6','TOKAK'),
													 ('Mehmet7','TOKAK');
													 
													
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


as $$create or replace procedure addpersonel(firstname in varchar(50),lastname in varchar(50),resultText inout varchar)

declare
begin
	
	insert  into  personprofil (firstname,lastname) values(firstname,lastname);
	
resultText=concat(firstname,' ',lastname,' kayıt eklendi');
end 
$$ language 'plpgsql';


call addpersonel('ali3','sunal3',null);




create or replace function addpersonelf(firstname in varchar(50),lastname in varchar(50))
returns varchar(100) 
as $$
declare rslt varchar(100);
begin 
	insert  into  personprofil (firstname,lastname) values(firstname,lastname);
rslt=concat(firstname,' ',lastname,' kayıt eklendi');
	return  rslt;
end $$ language 'plpgsql';


select * from addpersonelf('ali1','sunal1')

create or replace function updatepersonelf(id in int4,fname in varchar(50),lname in varchar(50))
returns varchar(100) 
as $$
declare rslt varchar(100);
begin 
	update personprofil set firstname=fname,lastname=lname where personprofilid=id;
rslt=concat(fname,' ',lname,' kayıt güncellendi. (F)');
	return  rslt;
end $$ language 'plpgsql';

select * from updatepersonelf(3,'ali3','tokak3')


create or replace procedure updatepersonelp(id in int4,fname in varchar(50),lname in varchar(50),resultText inout varchar)
as $$
declare
begin
	
	update personprofil set firstname=fname,lastname=lname where personprofilid=id;
	
resultText=concat(fname,' ',lname,' kayıt guncellendi.(P)');
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
rslt=concat('personprofilid= ',id,' olan  kayıt silindi. (F)');
	return  rslt;
end $$ language 'plpgsql';

select * from deletepersonelf(4)



--delete prosedure
create or replace procedure deletepersonelp(id in int4,resultText inout varchar)
as $$
declare
begin
	
	delete from personprofil where personprofilid=id;
	
resultText=concat('personprofilid= ',id,' olan  kayıt silindi. (P)');
end 
$$ language 'plpgsql';

call deletepersonelp(5,null);

