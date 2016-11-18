SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `sga` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
CREATE SCHEMA IF NOT EXISTS `sga` DEFAULT CHARACTER SET utf8 ;
USE `sga` ;

-- -----------------------------------------------------
-- Table `sga`.`motorista`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`motorista` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(150) NOT NULL ,
  `cnh` VARCHAR(45) NOT NULL ,
  `cpf` VARCHAR(45) NOT NULL ,
  `vencimento` DATETIME NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sga`.`transportadoras`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`transportadoras` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `Nome` VARCHAR(45) NOT NULL ,
  `Apelido` VARCHAR(45) NOT NULL ,
  `Cnpj` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`tipo_caminhao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`tipo_caminhao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  `foto` BLOB NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`caminhao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`caminhao` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `idtipo_caminhao` INT(11) NOT NULL ,
  `placa` VARCHAR(15) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_caminhao_tipo_caminhao1_idx` (`idtipo_caminhao` ASC) ,
  CONSTRAINT `fk_caminhao_tipo_caminhao1`
    FOREIGN KEY (`idtipo_caminhao` )
    REFERENCES `sga`.`tipo_caminhao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sga`.`romaneio`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`romaneio` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `idmotorista` INT NOT NULL ,
  `idtransportadoras` INT(11) NOT NULL ,
  `idcaminhao` INT NOT NULL ,
  `data` DATETIME NULL ,
  `obs` VARCHAR(1024) NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_romaneio_motorista_idx` (`idmotorista` ASC) ,
  INDEX `fk_romaneio_transportadoras1_idx` (`idtransportadoras` ASC) ,
  INDEX `fk_romaneio_caminhao1_idx` (`idcaminhao` ASC) ,
  CONSTRAINT `fk_romaneio_motorista`
    FOREIGN KEY (`idmotorista` )
    REFERENCES `sga`.`motorista` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_romaneio_transportadoras1`
    FOREIGN KEY (`idtransportadoras` )
    REFERENCES `sga`.`transportadoras` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_romaneio_caminhao1`
    FOREIGN KEY (`idcaminhao` )
    REFERENCES `sga`.`caminhao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `sga` ;

-- -----------------------------------------------------
-- Table `sga`.`acerto_lote`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`acerto_lote` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `cd` VARCHAR(45) NOT NULL ,
  `item` VARCHAR(45) NOT NULL ,
  `descricao` VARCHAR(45) NOT NULL ,
  `lote` VARCHAR(45) NOT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 288
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`fabricantes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`fabricantes` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  `site` VARCHAR(512) NULL DEFAULT NULL ,
  `email` VARCHAR(45) NULL DEFAULT NULL ,
  `tel1` VARCHAR(45) NULL DEFAULT NULL ,
  `tel2` VARCHAR(45) NULL DEFAULT NULL ,
  `tel3` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`grupo_itens`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`grupo_itens` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`prioridades`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`prioridades` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`itens`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`itens` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idfabricantes` INT(11) NULL DEFAULT NULL ,
  `idgrupo_itens` INT(11) NOT NULL ,
  `idprioridades` INT(11) NOT NULL ,
  `nome` VARCHAR(45) NOT NULL ,
  `ncm` VARCHAR(45) NULL DEFAULT NULL ,
  `valor` DOUBLE NULL DEFAULT NULL ,
  `localizacao` VARCHAR(45) NULL DEFAULT NULL ,
  `obs` VARCHAR(1024) NULL DEFAULT NULL ,
  `item_estoque` TINYINT(1) NULL DEFAULT NULL ,
  `maetrial_consumo` TINYINT(1) NULL DEFAULT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  `min` DOUBLE NOT NULL ,
  `medio` DOUBLE NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_itens_fabricantes_idx` (`idfabricantes` ASC) ,
  INDEX `fk_itens_grupo_itens1_idx` (`idgrupo_itens` ASC) ,
  INDEX `fk_itens_prioridades1_idx` (`idprioridades` ASC) ,
  CONSTRAINT `fk_itens_fabricantes`
    FOREIGN KEY (`idfabricantes` )
    REFERENCES `sga`.`fabricantes` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_itens_grupo_itens1`
    FOREIGN KEY (`idgrupo_itens` )
    REFERENCES `sga`.`grupo_itens` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_itens_prioridades1`
    FOREIGN KEY (`idprioridades` )
    REFERENCES `sga`.`prioridades` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`add_itens`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`add_itens` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `iditens` INT(11) NOT NULL ,
  `pedido` VARCHAR(45) NULL DEFAULT NULL ,
  `data_entrada` DATETIME NOT NULL ,
  `data_pedido` DATETIME NULL DEFAULT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_add_itens_itens1_idx` (`iditens` ASC) ,
  CONSTRAINT `fk_add_itens_itens1`
    FOREIGN KEY (`iditens` )
    REFERENCES `sga`.`itens` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`requisitantes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`requisitantes` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  `cc` VARCHAR(10) NULL DEFAULT NULL ,
  `codigo` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`baixa_items`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`baixa_items` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `iditens` INT(11) NOT NULL ,
  `idrequisitantes` INT(11) NOT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  `os` VARCHAR(45) NULL DEFAULT NULL ,
  `data` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_baixa_items_itens1_idx` (`iditens` ASC) ,
  INDEX `fk_baixa_items_requisitantes1_idx` (`idrequisitantes` ASC) ,
  CONSTRAINT `fk_baixa_items_itens1`
    FOREIGN KEY (`iditens` )
    REFERENCES `sga`.`itens` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_baixa_items_requisitantes1`
    FOREIGN KEY (`idrequisitantes` )
    REFERENCES `sga`.`requisitantes` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 20
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`centrodistribuicao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`centrodistribuicao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  `cidade` VARCHAR(45) NOT NULL ,
  `cnpj` VARCHAR(20) NOT NULL ,
  `estado` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`condicaoestoque`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`condicaoestoque` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `data` DATETIME NOT NULL ,
  `posicao` VARCHAR(45) NULL DEFAULT NULL ,
  `numeroitem` VARCHAR(45) NULL DEFAULT NULL ,
  `descricao` VARCHAR(45) NULL DEFAULT NULL ,
  `quantidade` DOUBLE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`faturas`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`faturas` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idTransportadoras` INT(11) NOT NULL ,
  `idCentroDistribuicao` INT(11) NOT NULL ,
  `Fatura` VARCHAR(20) NOT NULL ,
  `Vlr_Bruto` DOUBLE NULL DEFAULT NULL ,
  `Vlr_Liquido` DOUBLE NULL DEFAULT NULL ,
  `Data_Vencimento` DATETIME NULL DEFAULT NULL ,
  `Data_Emissao` DATETIME NULL DEFAULT NULL ,
  `Data_inclusao` DATETIME NULL DEFAULT NULL ,
  `NomeSacado` VARCHAR(45) NULL DEFAULT NULL ,
  `ENDERECO` VARCHAR(45) NULL DEFAULT NULL ,
  `MUNICIPIO` VARCHAR(45) NULL DEFAULT NULL ,
  `BAIRRO` VARCHAR(45) NULL DEFAULT NULL ,
  `ESTADO` VARCHAR(45) NULL DEFAULT NULL ,
  `CEP` VARCHAR(45) NULL DEFAULT NULL ,
  `INSCEST` VARCHAR(45) NULL DEFAULT NULL ,
  `CNPJMF` VARCHAR(45) NULL DEFAULT NULL ,
  `OBS` VARCHAR(1024) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_Faturas_Transportadoras_idx` (`idTransportadoras` ASC) ,
  INDEX `fk_Faturas_CentroDistribuicao1_idx` (`idCentroDistribuicao` ASC) ,
  CONSTRAINT `fk_Faturas_CentroDistribuicao1`
    FOREIGN KEY (`idCentroDistribuicao` )
    REFERENCES `sga`.`centrodistribuicao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Faturas_Transportadoras`
    FOREIGN KEY (`idTransportadoras` )
    REFERENCES `sga`.`transportadoras` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`conhecimento`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`conhecimento` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idFaturas` INT(11) NOT NULL ,
  `chave` VARCHAR(48) NOT NULL ,
  `emissao` DATETIME NULL DEFAULT NULL ,
  `conhecimento` VARCHAR(6) NOT NULL ,
  `nota_fiscal` VARCHAR(15) NOT NULL ,
  `Origem` VARCHAR(15) NOT NULL ,
  `R_nome` VARCHAR(45) NULL DEFAULT NULL ,
  `R_cnpj` VARCHAR(45) NULL DEFAULT NULL ,
  `R_incr` VARCHAR(45) NULL DEFAULT NULL ,
  `R_cidade` VARCHAR(15) NULL DEFAULT NULL ,
  `R_telefone` VARCHAR(15) NULL DEFAULT NULL ,
  `D_nome` VARCHAR(45) NULL DEFAULT NULL ,
  `D_cnpj` VARCHAR(45) NULL DEFAULT NULL ,
  `D_incr` VARCHAR(45) NULL DEFAULT NULL ,
  `D_cidade` VARCHAR(15) NULL DEFAULT NULL ,
  `D_telefone` VARCHAR(45) NULL DEFAULT NULL ,
  `Tomador_cnpj` VARCHAR(45) NULL DEFAULT NULL ,
  `Produto` VARCHAR(45) NULL DEFAULT NULL ,
  `Valor_mercadoria` DOUBLE NULL DEFAULT NULL ,
  `Peso` DOUBLE NOT NULL ,
  `Volume` DOUBLE NULL DEFAULT NULL ,
  `Volume_esperado` DOUBLE NULL DEFAULT NULL ,
  `Icms` DOUBLE NULL DEFAULT NULL ,
  `Valor_total` DOUBLE NOT NULL ,
  `Valor_receber` DOUBLE NOT NULL ,
  `Valor_receber_esperado` DOUBLE NOT NULL ,
  `Motorista` VARCHAR(45) NULL DEFAULT NULL ,
  `Placa` VARCHAR(15) NULL DEFAULT NULL ,
  `Obs` VARCHAR(1024) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_Conhecimento_Faturas1_idx` (`idFaturas` ASC) ,
  CONSTRAINT `fk_Conhecimento_Faturas1`
    FOREIGN KEY (`idFaturas` )
    REFERENCES `sga`.`faturas` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`estados`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`estados` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `uf` VARCHAR(4) NOT NULL ,
  `nome` VARCHAR(45) NOT NULL ,
  `local` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 32
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`permissao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`permissao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `modulo` VARCHAR(45) NOT NULL ,
  `programa` VARCHAR(120) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 22
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`permissao_usuario`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`permissao_usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idusuario` INT(11) NOT NULL ,
  `idpermissao` INT(11) NOT NULL ,
  PRIMARY KEY (`id`, `idusuario`) )
ENGINE = InnoDB
AUTO_INCREMENT = 151
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`produtos`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`produtos` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idsap` VARCHAR(10) NOT NULL ,
  `nome` VARCHAR(45) NOT NULL ,
  `peso` DOUBLE NULL DEFAULT NULL ,
  `conversao` DOUBLE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`retorno_lote`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`retorno_lote` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idacerto_lote` INT(11) NOT NULL ,
  `data_baixa` DATETIME NOT NULL ,
  `docsap` VARCHAR(45) NULL DEFAULT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  `codigo` INT(11) NULL DEFAULT '0' ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_retorno_lote_acerto_lote1_idx` (`idacerto_lote` ASC) ,
  CONSTRAINT `fk_retorno_lote_acerto_lote1`
    FOREIGN KEY (`idacerto_lote` )
    REFERENCES `sga`.`acerto_lote` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 75
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`saida_lote`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`saida_lote` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idretorno` INT(11) NOT NULL ,
  `nota` VARCHAR(45) NOT NULL ,
  `quantidade` DOUBLE NOT NULL ,
  `obs` VARCHAR(1024) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_saida_lote_retorno_lote_idx` (`idretorno` ASC) ,
  CONSTRAINT `fk_saida_lote_retorno_lote`
    FOREIGN KEY (`idretorno` )
    REFERENCES `sga`.`retorno_lote` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`tabelafrete_carreta`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`tabelafrete_carreta` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idTransportadoras` INT(11) NOT NULL ,
  `idCentroDistribuicao` INT(11) NOT NULL ,
  `Destino` VARCHAR(4) NOT NULL ,
  `Valor_Icms` DOUBLE NOT NULL ,
  `Valor_Pallets` DOUBLE NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_TabelaFrete_Carreta_Transportadoras1_idx` (`idTransportadoras` ASC) ,
  INDEX `fk_TabelaFrete_Carreta_CentroDistribuicao1_idx` (`idCentroDistribuicao` ASC) ,
  CONSTRAINT `fk_TabelaFrete_Carreta_CentroDistribuicao1`
    FOREIGN KEY (`idCentroDistribuicao` )
    REFERENCES `sga`.`centrodistribuicao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TabelaFrete_Carreta_Transportadoras1`
    FOREIGN KEY (`idTransportadoras` )
    REFERENCES `sga`.`transportadoras` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`tabelafrete_fracao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`tabelafrete_fracao` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idTransportadoras` INT(11) NOT NULL ,
  `idCentroDistribuicao` INT(11) NOT NULL ,
  `Destino` VARCHAR(45) NOT NULL ,
  `Valor_Icms` DOUBLE NOT NULL ,
  `Valor_Pallets` DOUBLE NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_TabelaFrete_Fracao_Transportadoras1_idx` (`idTransportadoras` ASC) ,
  INDEX `fk_TabelaFrete_Fracao_CentroDistribuicao1_idx` (`idCentroDistribuicao` ASC) ,
  CONSTRAINT `fk_TabelaFrete_Fracao_CentroDistribuicao1`
    FOREIGN KEY (`idCentroDistribuicao` )
    REFERENCES `sga`.`centrodistribuicao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TabelaFrete_Fracao_Transportadoras1`
    FOREIGN KEY (`idTransportadoras` )
    REFERENCES `sga`.`transportadoras` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`tabelafrete_truck`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`tabelafrete_truck` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `idTransportadoras` INT(11) NOT NULL ,
  `idCentroDistribuicao` INT(11) NOT NULL ,
  `Destino` VARCHAR(45) NOT NULL ,
  `Valor_Icms` DOUBLE NOT NULL ,
  `Valor_Pallets` DOUBLE NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_TabelaFrete_Truck_Transportadoras1_idx` (`idTransportadoras` ASC) ,
  INDEX `fk_TabelaFrete_Truck_CentroDistribuicao1_idx` (`idCentroDistribuicao` ASC) ,
  CONSTRAINT `fk_TabelaFrete_Truck_CentroDistribuicao1`
    FOREIGN KEY (`idCentroDistribuicao` )
    REFERENCES `sga`.`centrodistribuicao` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TabelaFrete_Truck_Transportadoras1`
    FOREIGN KEY (`idTransportadoras` )
    REFERENCES `sga`.`transportadoras` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`tipousuario`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`tipousuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `Tipo` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sga`.`usuarios`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sga`.`usuarios` (
  `id` INT(11) NOT NULL AUTO_INCREMENT ,
  `IdTipoUsuario` INT(11) NOT NULL ,
  `usuario` VARCHAR(45) NOT NULL ,
  `senha` VARCHAR(45) NOT NULL ,
  `nome` VARCHAR(45) NOT NULL ,
  `foto` BLOB NULL DEFAULT NULL ,
  `email` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_Usuarios_TipoUsuario1_idx` (`IdTipoUsuario` ASC) ,
  CONSTRAINT `fk_Usuarios_TipoUsuario1`
    FOREIGN KEY (`IdTipoUsuario` )
    REFERENCES `sga`.`tipousuario` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Placeholder table for view `sga`.`cds`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sga`.`cds` (`ID` INT, `Centro` INT, `UF` INT, `Nome` INT, `Local` INT, `CNPJ` INT);

-- -----------------------------------------------------
-- View `sga`.`cds`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `sga`.`cds`;
USE `sga`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`sga`@`%` SQL SECURITY DEFINER VIEW `sga`.`cds` AS select `x`.`id` AS `ID`,`x`.`nome` AS `Centro`,`y`.`uf` AS `UF`,`y`.`nome` AS `Nome`,`y`.`local` AS `Local`,`x`.`cnpj` AS `CNPJ` from (`sga`.`centrodistribuicao` `x` join `sga`.`estados` `y`) where (`x`.`estado` = `y`.`uf`);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
