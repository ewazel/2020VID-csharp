DROP TABLE IF EXISTS dbo.game_state;
CREATE TABLE dbo.game_state (
    id int NOT NULL PRIMARY KEY,
    current_map varchar(max) NOT NULL,
    saved_at datetime2 DEFAULT GETDATE() NOT NULL,
    player_id integer NOT NULL
);
DROP TABLE IF EXISTS dbo.player;
CREATE TABLE dbo.player (
    id int NOT NULL PRIMARY KEY,
    player_name varchar(max) NOT NULL,
    hp integer NOT NULL,
    x integer NOT NULL,
    y integer NOT NULL
);
ALTER TABLE ONLY dbo.game_state
    ADD CONSTRAINT fk_player_id FOREIGN dbo.KEY (player_id) REFERENCES dbo.player(id);