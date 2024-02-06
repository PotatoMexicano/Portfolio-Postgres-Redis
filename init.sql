CREATE TABLE IF NOT EXISTS "Produtos" (
	"Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	"Name" text NOT NULL,
	"CreateAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT "PK_Produtos" PRIMARY KEY ("Id")
);

-- Permissions

ALTER TABLE public."Produtos" OWNER TO postgres;
GRANT ALL ON TABLE public."Produtos" TO postgres;


INSERT INTO "Produtos" ("Name") VALUES('Banana');
INSERT INTO "Produtos" ("Name") VALUES('Maça');
INSERT INTO "Produtos" ("Name") VALUES('Uva');
INSERT INTO "Produtos" ("Name") VALUES('Pêra');
INSERT INTO "Produtos" ("Name") VALUES('Goiaba');
INSERT INTO "Produtos" ("Name") VALUES('Tangerina');
INSERT INTO "Produtos" ("Name") VALUES('Zap');
INSERT INTO "Produtos" ("Name") VALUES('Melão');