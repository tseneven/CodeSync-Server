import { Test, TestingModule } from '@nestjs/testing';
import { MainusersController } from './mainusers.controller';
import { MainusersService } from './mainusers.service';

describe('MainusersController', () => {
  let controller: MainusersController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MainusersController],
      providers: [MainusersService],
    }).compile();

    controller = module.get<MainusersController>(MainusersController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
